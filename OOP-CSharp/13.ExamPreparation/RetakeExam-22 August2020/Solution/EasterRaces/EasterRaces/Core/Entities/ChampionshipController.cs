using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository carsRepository;
        private readonly DriverRepository driversRepository;
        private readonly RaceRepository racesRepository;

        public ChampionshipController()
        {
            this.carsRepository = new CarRepository();
            this.driversRepository = new DriverRepository();
            this.racesRepository = new RaceRepository();
        }


        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.driversRepository.GetByName(driverName);
            var car = this.carsRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";

        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.racesRepository.GetByName(raceName);
            var driver = this.driversRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carsRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.carsRepository.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var driver = new Driver(driverName);

            if (driversRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            this.driversRepository.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = new Race(name, laps);

            if (racesRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            this.racesRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.racesRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var drivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                                                                   .ToList();
            this.racesRepository.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {drivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {drivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {drivers[2].Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
