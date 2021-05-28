using EasterRaces.Models.Drivers.Contracts;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public DriverRepository() : base()
        {
        }

        public override IDriver GetByName(string name) => this.Models.FirstOrDefault(m => m.Name == name);
    }
}
