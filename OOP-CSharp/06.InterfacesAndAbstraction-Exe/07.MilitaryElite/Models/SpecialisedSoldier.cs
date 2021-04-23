using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.Interfaces;
using System;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corps corps;

            bool parse = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parse)
            {
                throw new InvalidCorpsException();
            }

            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
