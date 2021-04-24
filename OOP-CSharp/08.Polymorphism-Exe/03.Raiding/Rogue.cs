namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int BASE_POWER = 80;

        public Rogue(string name) : base(name, BASE_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} – {this.Name} hit for {this.Power} damage";
        }
    }
}
