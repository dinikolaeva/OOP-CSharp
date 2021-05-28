using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitDriver unitDriver;
        private UnitCar unitCar;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.unitDriver = new UnitDriver("Pesho", new UnitCar("BMV", 300, 3000));
            this.unitCar = new UnitCar("Peugeot", 250, 2500);
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void CheckThatRaceCtorWorkCorrect()
        {
            Assert.IsNotNull(this.raceEntry.Counter);
        }

        [Test]
        public void CheckThatAddDriverMethodWorCorrect()
        {
            var driver = new UnitDriver("Mitko", new UnitCar("Peugeot", 250, 2500));

            Assert.AreEqual($"Driver {driver.Name} added in race.", raceEntry.AddDriver(driver));
        }

        [Test]
        [TestCase(null)]
        public void ThrowExceptionIfDriverIsNull(UnitDriver driver)
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void ThrowExceptionIfDriverAlreadyExist()
        {
            var driver1 = new UnitDriver("Stamat", new UnitCar("Mazda", 200, 3000));
            var driver2 = new UnitDriver("Stamat", new UnitCar("BMW", 300, 3000));
            raceEntry.AddDriver(driver1);
            Assert.Throws<InvalidOperationException>(()=>this.raceEntry.AddDriver(driver2));
        }

        [Test]
        public void CheckThatCalculateAverageHorsePowerMethodWorkCorrect()
        {
            var driver1 = new UnitDriver("Stamat", new UnitCar("Mazda", 200, 3000));
            var driver2 = new UnitDriver("Vrgil", new UnitCar("BMW", 300, 3000));
            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);

            Assert.AreEqual(250, raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void ThrowExceptionIfCountOfParticipantsIsLessThen2()
        {
            var driver1 = new UnitDriver("Stamat", new UnitCar("Mazda", 200, 3000));
            raceEntry.AddDriver(driver1);

            Assert.Throws<InvalidOperationException>(()=>this.raceEntry.CalculateAverageHorsePower());
        }
    }
}