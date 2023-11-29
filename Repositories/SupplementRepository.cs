using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;
        public SupplementRepository()
        {
            supplements= new List<ISupplement>();
        }
        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            var supplement = supplements
                .FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);
            return supplement;
        }

        public IReadOnlyCollection<ISupplement> Models()=>this.supplements.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            var itemToRemove = supplements.
                FirstOrDefault(tn => tn.GetType().Name == typeName);

            if(itemToRemove != null)
            {
                supplements.Remove(itemToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
