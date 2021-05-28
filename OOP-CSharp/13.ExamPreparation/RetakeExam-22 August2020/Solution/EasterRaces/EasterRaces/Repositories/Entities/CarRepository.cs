using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public CarRepository()
            :base()
        {
        }

        public override ICar GetByName(string name) => this.Models.FirstOrDefault(m => m.Model == name);
    }
}
