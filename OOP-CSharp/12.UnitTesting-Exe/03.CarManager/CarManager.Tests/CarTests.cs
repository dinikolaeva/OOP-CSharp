using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Make", "Model", 10.0, 100.0);
        }

        [Test]
        public void TestThatCarHaveValidPropMake()
        {
            Assert.That(car.Make, Is.EqualTo("Make"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ThrowExceptionIfMakeIsNotValid(string make)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(make, "Model", 10.0, 100.0));
        }

        [Test]
        public void TestThatCarHaveValidPropMidel()
        {
            Assert.That(car.Model, Is.EqualTo("Model"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ThrowExceptionIfModelIsNotValid(string model)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Make", model, 10.0, 100.0));
        }

        [Test]
        public void TestThatCarHaveValidPropFuelConsumption()
        {
            Assert.That(car.FuelConsumption, Is.EqualTo(10.0));
        }

        [Test]
        [TestCase(-12.0)]
        [TestCase(0.0)]
        public void ThrowExceptionWhenFuelConsumptionIsLessThanZero(double fuelConsumtion)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Make", "Model", fuelConsumtion, 100.0));
        }

        [Test]
        public void TestThatCarHaveValidFuelAmount()
        {
            Assert.That(car.FuelAmount, Is.EqualTo(0.0));
        }

        [Test]
        public void TestThatCarHaveValidPropFuelCapacity()
        {
            Assert.That(car.FuelCapacity, Is.EqualTo(100.0));
        }

        [Test]
        [TestCase(-15.0)]
        [TestCase(0.0)]
        public void ThrowExceptionWhenFuelCapacityIsLessThanZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Make", "Model", 10.0, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void ThrowExceptionWhenRefuelAmountIsLessThenZero(double fuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuel));
        }

        [Test]
        [TestCase(20)]
        public void CheckThatMethodRefuelWorksCorrectly(double fuel)
        {
            car.Refuel(fuel);
            Assert.That(this.car.FuelAmount, Is.EqualTo(20));
        }

        [Test]
        [TestCase(120)]
        public void CheckThatWhenFuelAmountIsBiggerThenFuelCapacityShouldBeEqualToFuelCapacity(double fuelAmount)
        {
            car.Refuel(fuelAmount);
            Assert.That(this.car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        [TestCase(120.0, 5.0)]
        public void CheckThatDriveMethodDecreaceFuelAmount(double fuel, double km)
        {
            car.Refuel(fuel);
            car.Drive(km);
            Assert.That(this.car.FuelAmount, Is.EqualTo(99.5));
        }

        [Test]
        [TestCase(1000)]
        public void ThrowExceptionIfFuelAmountIsNotEnaught(double distance)
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(distance));
        }
    }
}