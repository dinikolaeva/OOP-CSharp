using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Entities
{
    public class Person
    {
        private const int MIN_VALUE = 12;
        private const int MAX_VALUE = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequiredAttribute]
        public string FullName { get; private set; }

        [MyRangeAttribute(MIN_VALUE, MAX_VALUE)]
        public int Age { get; private set; }
    }
}
