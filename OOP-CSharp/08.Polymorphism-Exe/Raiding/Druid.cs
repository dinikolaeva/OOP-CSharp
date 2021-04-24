namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int BASE_POWER = 80;

        public Druid(string name) : base(name)
        {
            this.Power = BASE_POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
