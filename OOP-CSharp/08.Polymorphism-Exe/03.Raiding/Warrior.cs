namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int BASE_POWER = 100;

        public Warrior(string name) : base(name, BASE_POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {this.Name} hit for {this.Power} damage";
        }
    }
}
