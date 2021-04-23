using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    public interface ICommando:ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Misions { get; }

        void AddMission(IMission mision);
    }
}
