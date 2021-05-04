using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LossesHelthIfDummyAttacked()
        {
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(5);

            //Assert
            Assert.That(dummy.Health,Is.EqualTo(5));
        }

        [Test]
        public void DeadDummyThrowException()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.That(dummy.GiveExperience(), Is.EqualTo(10));
        }

        [Test]
        [TestCase(10, 10)]
        public void IfDummyCantGiveXp(int health, int experience)
        {
            Dummy target = new Dummy(health, experience);


            Assert.Throws<InvalidOperationException>(() => target.GiveExperience());
        }
    }
}
