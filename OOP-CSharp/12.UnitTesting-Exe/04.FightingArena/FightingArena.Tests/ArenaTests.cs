//using FightingArena;
using NUnit.Framework;
using System;

namespace FightingArena
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void CheckThatConstructorWorkCorrectly()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test]
        public void CheckThatMethodEnrollWorkCorrectly()
        {
            Warrior warrior = new Warrior("Didi", 10, 100);
            this.arena.Enroll(warrior);
            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void ThrowExceptionWhenWarriorAlredyExist()
        {
            Warrior warrior = new Warrior("Didi", 10, 100);
            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior));
        }

        [Test]
        public void CheckThatCounterWorkCorrectly()
        {
            int expectedCount = 1;
            Warrior warrior = new Warrior("Didi", 10, 100);
            this.arena.Enroll(warrior);
            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void CheckThatMethodFaightWorkCorrectly()
        {

            Warrior attacker = new Warrior("Didi", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            int expectedAttackerHP = 95;
            int expectedDefenderHP = 40;

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void ThrowsExceptionWhenFightingWhitMissingWarrier()
        {
            Warrior attacker = new Warrior("Didi", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker.Name, defender.Name));
        }
    }
}
