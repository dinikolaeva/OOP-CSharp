using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTest
    {
        [Test]
        public void AxeLosesDurabilityAfterAttak()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }

        [Test]
        public void AttackingWithABrokenAxe()
        {
            Axe axe = new Axe(10, -2);
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}