namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int BASE_POWER = 100;

        public Paladin(string name) : base(name)
        {
            this.Power = BASE_POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
