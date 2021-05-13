//using FightingArena;
using NUnit.Framework;
using System;

namespace FightingArena
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Didi", 100, 200);
        }

        [Test]
        public void CheckThatConstructorWorkCorrectly()
        {
            string expectedName = "Didi";
            int expectetdDamage = 100;
            int expectedHP = 200;

            Assert.AreEqual(expectedName, this.warrior.Name);
            Assert.AreEqual(expectetdDamage, this.warrior.Damage);
            Assert.AreEqual(expectedHP, this.warrior.HP);
        }

        [Test]
        [TestCase("")]
        [TestCase("    ")]
        [TestCase(null)]
        public void ThrowExceptionWhenNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => this.warrior = new Warrior(name, 100, 200));
        }

        [Test]
        [TestCase(-100)]
        [TestCase(0)]
        public void ThrowExceptionWhenDamageIsLessThanZero(int damage)
        {
            Assert.Throws<ArgumentException>(() => this.warrior = new Warrior("Name", damage, 200));
        }

        [Test]
        [TestCase(-50)]
        public void ThrowExceptionWhenHPIsLessThanZero(int HP)
        {
            Assert.Throws<ArgumentException>(() => this.warrior = new Warrior("Name", 100, HP));
        }

        [Test]
        public void TestThatAttackMethodWorkCorrectly()
        {
            int expectedWarriorHp = 195;
            int expectedDefenderHP = 10;

            Warrior defender = new Warrior("Gosho", 5, 110);

            this.warrior.Attack(defender);

            Assert.AreEqual(expectedWarriorHp, this.warrior.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void ThrowsExceptionWhenHPIsNotEnough()
        {
            var attacker = new Warrior("Pesho", 10, 25);
            var defender = new Warrior("Gosho", 5, 45);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void ThrowsExceptionWhenDefenderHPIsNotEnough()
        {
            var attacker = new Warrior("Pesho", 10, 45);
            var defender = new Warrior("Gosho", 5, 25);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void ThrowsExceptionWhenAttackStrongerEnemy()
        {
            var attacker = new Warrior("Pesho", 10, 35);
            var defender = new Warrior("Gosho", 40, 60);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void TestThatAttacerKilledEnemy()
        {
            int expectedattackerHp = 155;
            int expectedDefenderHP = 0;

            var attacker = new Warrior("Pesho", 100, 200);
            var defender = new Warrior("Gosho", 45, 40);

            attacker.Attack(defender);

            Assert.AreEqual(expectedattackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}