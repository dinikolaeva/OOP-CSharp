namespace Raiding
{
    public class Paladin : BaseHero
    {
        public const int BASE_POWER = 100;

        public Paladin(string name) : base(name, BASE_POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{nameof(Paladin)} - {this.Name} healed for {this.Power}";
        }
    }
}
