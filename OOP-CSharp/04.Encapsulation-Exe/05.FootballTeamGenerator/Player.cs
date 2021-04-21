using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const string EXCEPTION_OF_STATS = "{0} should be between 0 and 100.";
        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Name = name;

            if (endurance < 0 || endurance > 100)
            {
                throw new ArgumentException(String.Format(EXCEPTION_OF_STATS, "Endurance"));
            }
            this.endurance = endurance;

            if (sprint < 0 || sprint > 100)
            {
                throw new ArgumentException(String.Format(EXCEPTION_OF_STATS, "Sprint"));
            }
            this.sprint = sprint;

            if (dribble < 0 || dribble > 100)
            {
                throw new ArgumentException(String.Format(EXCEPTION_OF_STATS, "Dribble"));
            }
            this.dribble = dribble;

            if (passing < 0 || passing > 100)
            {
                throw new ArgumentException(String.Format(EXCEPTION_OF_STATS, "Passing"));
            }
            this.passing = passing;

            if (shooting < 0 || shooting > 100)
            {
                throw new ArgumentException(String.Format(EXCEPTION_OF_STATS, "Shooting"));
            }
            this.shooting = shooting;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public double Stat
        {
            get => (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5;
        }
    }
}
