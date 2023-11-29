using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            if(typeName!= "DomesticAssistant" &&  typeName!= "IndustrialAssistant")
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
            else if(typeName == "DomesticAssistant")
            {
                IRobot robot = new DomesticAssistant(model);
                robots.AddNew(robot);
                return String.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
            }
            else
            {
                IRobot robot = new IndustrialAssistant(model);
                robots.AddNew(robot);
                return String.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
            }
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != "SpecializedArm" && typeName != "LaserRadar")
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            else if (typeName == "SpecializedArm")
            {
                ISupplement supplement = new SpecializedArm();
                supplements.AddNew(supplement);
                return String.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
            }
            else
            {
                ISupplement supplement = new LaserRadar();
                supplements.AddNew(supplement);
                return String.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
            }
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var robotsValid = robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard));
            if(!robotsValid.Any())
            {
                return String.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }
            robotsValid = robotsValid.OrderByDescending(b => b.BatteryLevel);
            int sum = 0;
            foreach (var robot in robotsValid)
            {
                sum += robot.BatteryLevel;
            }

            if(sum<totalPowerNeeded)
            {
                return String.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sum);
            }

            int robotCount = 0;
            foreach(var robot in robotsValid)
            {
                if(robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    robotCount++;
                    break;
                }
                else if(robot.BatteryLevel < totalPowerNeeded)
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    robotCount++;
                }
            }
            return String.Format(OutputMessages.PerformedSuccessfully, serviceName, robotCount);
        }

        public string Report()
        {
            StringBuilder sb = new();

            var robotsSorted = robots.Models().OrderByDescending(b => b.BatteryLevel).ThenBy(c => c.BatteryCapacity);

            foreach(IRobot r in robotsSorted)
            {
                sb.AppendLine(r.ToString());
            }    
            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            var robotsValid=robots.Models().Where(x => x.Model == model && x.BatteryLevel<0.5*x.BatteryCapacity).ToList();
            int robotsFed = 0;
            foreach(var robot in robotsValid)
            {
                robot.Eating(minutes);
                robotsFed++;
            }
            return String.Format(OutputMessages.RobotsFed, robotsFed);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);
            int supplementInterface = supplement.InterfaceStandard;
            var robotsInterface = robots.Models().Where(r => !(r.InterfaceStandards.Contains(supplementInterface)));
            robotsInterface=robotsInterface.Where(r => r.Model== model);

            if(robotsInterface.Any())
            {
                IRobot robot = robotsInterface.First();
                robot.InstallSupplement(supplement);
                supplements.RemoveByName(supplementTypeName);
                return String.Format(OutputMessages.UpgradeSuccessful, model,supplementTypeName);
            }
            return String.Format(OutputMessages.AllModelsUpgraded, model);
            
        }
    }
}
