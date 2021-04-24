namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int BASE_POWER = 80;

        public Rogue(string name) : base(name)
        {
            this.Power = BASE_POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
