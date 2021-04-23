using _07.MilitaryElite.Contracts;
using System;

namespace _07.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }
        public string Enviroment { get; private set; }

        public override string ToString()
        {
            return base.ToString().TrimEnd() + Environment.NewLine + $"Code Number: {this.CodeNumber}";
        }
    }
}
