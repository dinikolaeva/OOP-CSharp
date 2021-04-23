using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Contracts
{
    public interface ISpy:ISoldier
    {
        int CodeNumber { get; }
    }
}
