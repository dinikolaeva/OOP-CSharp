//using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDatabase;

        [SetUp]
        public void SetUp()
        {
            this.extendedDatabase = new ExtendedDatabase();
        }

        [Test]
        public void TestThatConstructorWorksCorrectly()
        {
            Person[] arg = new Person[5];

            for (int i = 0; i < arg.Length; i++)
            {
                arg[i] = new Person(i, $"Username{i}");
            }

            this.extendedDatabase = new ExtendedDatabase(arg);

            Assert.AreEqual(arg.Length, this.extendedDatabase.Count);

            foreach (var person in arg)
            {
                Person expectedPerson = this.extendedDatabase.FindById(person.Id);
                Assert.AreEqual(expectedPerson, person);
            }
        }

        [Test]
        public void TestThatConstructorIsReachedArrayLimit()
        {
            Person[] arg = new Person[17];

            for (int i = 0; i < arg.Length; i++)
            {
                arg[i] = new Person(i, $"Username{i}");
            }

            Assert.Throws<ArgumentException>(() => this.extendedDatabase = new ExtendedDatabase(arg));
        }

        [Test]
        public void TetsThatExcseptionThrownWhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"Username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(17, "InvalidUsername")));
        }

        [Test]
        public void TestThatTrowExceptionIfUserAlredyExist()
        {
            var username = "Didi";

            extendedDatabase.Add(new Person(23, username));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(3, username)));
        }

        [Test]
        public void TestThatTrowExceptionIfIDAlredyExist()
        {
            var Id = 258;

            extendedDatabase.Add(new Person(Id, "username1"));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(Id, "username2")));
        }

        [Test]
        public void TestThatCounterIncreasesIfUserIsValid()
        {
            this.extendedDatabase.Add(new Person(253, "Niki"));
            this.extendedDatabase.Add(new Person(254, "Didi"));

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.extendedDatabase.Count);
        }

        [Test]
        public void TestRemoveRangeIfDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }

        [Test]
        public void TestRemoveElementFromDatabase()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"Username{i}"));
            }

            this.extendedDatabase.Remove();

            Assert.AreEqual(n - 1, extendedDatabase.Count);
            Assert.Throws<InvalidOperationException>(()
            => this.extendedDatabase.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameThrowsExceptionWhenArgumentIsNotValid(string name)
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(name));
        }

        [Test]
        public void ThrowsExceptionWhenUsernameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindByUsername("Username"));
        }

        [Test]
        public void ReturnsExpectedUserByUsernameIfUserExist()
        {
            Person user = new Person(123, "Didi");

            this.extendedDatabase.Add(user);

            Person expectedUsername = this.extendedDatabase.FindByUsername(user.UserName);

            Assert.AreEqual(expectedUsername, user);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-15)]
        public void ThrowsExceptionWhenIdIsLessThanZero(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(id));
        }

        [Test]
        public void ThrowExceptionWhenIdDoNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(250));
        }

        [Test]
        public void ReturnsExpectedUserByIdIfUserExist()
        {
            Person person = new Person(123, "Didi");
            this.extendedDatabase.Add(person);

            Person expectedPerson = this.extendedDatabase.FindById(person.Id);

            Assert.AreEqual(expectedPerson, person);
        }
    }
}
