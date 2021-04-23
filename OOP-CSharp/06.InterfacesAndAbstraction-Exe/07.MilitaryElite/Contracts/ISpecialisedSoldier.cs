using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier:IPrivate
    {
        Corps Corps { get; }
    }
}
