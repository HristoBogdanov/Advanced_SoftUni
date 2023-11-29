using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private List<int> interfaceStandards;

        protected Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity= batteryCapacity;
            ConvertionCapacityIndex= conversionCapacityIndex;
            BatteryLevel = BatteryCapacity;
            interfaceStandards = new List<int>();
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if(string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public int BatteryCapacity
        {
            get => this.batteryCapacity;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                else
                {
                    this.batteryCapacity = value;
                }
            }
        }

        public int BatteryLevel
        {
            get=> this.batteryLevel;
            private set
            {
                this.batteryLevel = value;
            }
        }

        public int ConvertionCapacityIndex
        {
            get => this.convertionCapacityIndex;
            private set
            {
                this.convertionCapacityIndex = value;
            }
        }

        public IReadOnlyCollection<int> InterfaceStandards => this.interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {
            int energyProduced = minutes * ConvertionCapacityIndex;
            if(BatteryLevel == BatteryCapacity)
            {
                return;
            }
            else
            {
                BatteryLevel += energyProduced;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if(BatteryLevel>=consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel} ");
            if(this.interfaceStandards.Any())
            {
                sb.AppendLine($"--Supplements installed: {String.Join(" ", this.interfaceStandards)}");
            }
            else
            {
                sb.AppendLine($"--Supplements installed: none");
            }

            return sb.ToString().TrimEnd();
        }
    }
        
}
