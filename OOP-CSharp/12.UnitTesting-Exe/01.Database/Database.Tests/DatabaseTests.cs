using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] data = new int[] { 1, 2 };

        [SetUp]
        public void SetUp()
        {
            this.database = new Database(data);
        }

        [Test]
        public void TestIfConstructorWorkCorrectly()
        {
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, this.database.Count);
        }

        [Test]
        public void TestThatAddingIsCorrect()
        {
            int expectedCount = 3;

            this.database.Add(5);

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestThatCountIsOverflow()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>
                (() => this.database.Add(17));
        }

        [Test]
        public void TestRemovingCorrectly()
        {
            int expectedCount = 1;

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestRemovingWhenDatabaseIsEmpty()
        {
            for (int i = 0; i < 2; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void TestFetchWorksCorrectly()
        {
            int[] result = this.database.Fetch();

            CollectionAssert.AreEqual(this.data,result);
        }
    }
}