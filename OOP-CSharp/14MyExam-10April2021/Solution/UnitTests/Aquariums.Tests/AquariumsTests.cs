namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;
        private List<Fish> fishes;

        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("Big", 50);
            this.fish = new Fish("Gup");
            this.fishes = new List<Fish>();
        }

        [Test]
        public void CheckThatCtorWorkCorrect()
        {
            var expectedName = "Big";
            var expectedCapacity = 50;
            Assert.AreEqual(expectedName, this.aquarium.Name);
            Assert.AreEqual(expectedCapacity, this.aquarium.Capacity);
        }

        [Test]
        [TestCase(null)]
        public void ThrowExceptionIfNameOfAquariumIsNull(string aquariumName)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(aquariumName, 50));
        }

        [Test]
        [TestCase(-20)]
        [TestCase(-50)]
        public void ThrowExceptionIfCapacityOfAquariumIsLessThanZero
            (int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Dodo", capacity));
        }

        [Test]
        public void CheckIfCountIsNotNull()
        {
            Assert.IsNotNull(this.aquarium.Count);
        }

        [Test]
        public void CheckThatAddFishWorkCorrect()
        {
            this.aquarium.Add(this.fish);
            Assert.AreEqual(1, this.aquarium.Count);
        }

        [Test]
        public void ThrowExceptionWhenAquariumIsFull()
        {
            var aquarium2 = new Aquarium("Pup", 1);
            aquarium2.Add(this.fish);
            Assert.Throws<InvalidOperationException>(() => aquarium2.Add(new Fish("Pepa")));
        }

        [Test]
        public void CheckThatRemoveFishMethodWorkCorrect()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.RemoveFish("Gup");
            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void ThrowExceptionWhenRemoveFishIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Pipi"));
        }

        [Test]
        public void CheckThatSellFishMethodWorkCorrect()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.SellFish("Gup");
            Assert.AreEqual(false, this.fish.Available);
        }

        [Test]
        public void SellFishReturnFish()
        {
            this.aquarium.Add(this.fish);
            Assert.AreEqual(this.fish, this.aquarium.SellFish("Gup"));
        }

        [Test]
        public void ThrowExceptionWhenSellFishIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish(""));
        }

        [Test]
        public void CheckThatReportMethodWorkCorrect()
        {
            var fish2 = new Fish("Vergil");
            this.aquarium.Add(this.fish);
            this.aquarium.Add(fish2);
            string expectedOutut = "Fish available at Big: Gup, Vergil";
            Assert.AreEqual(expectedOutut, this.aquarium.Report());
        }
    }
}
