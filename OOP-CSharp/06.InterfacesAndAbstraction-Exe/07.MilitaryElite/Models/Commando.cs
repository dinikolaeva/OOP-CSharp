using _07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> misions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.misions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Misions => this.misions;

        public void AddMission(IMission mision)
        {
            this.misions.Add(mision);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mission in this.Misions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
