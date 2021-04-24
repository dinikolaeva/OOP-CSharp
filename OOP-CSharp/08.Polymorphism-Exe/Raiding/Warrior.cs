namespace Raiding
{
    public class Warrior : BaseHero
    {
       public Warrior(string name) : base(name)
        {
            this.Power = BASE_POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
