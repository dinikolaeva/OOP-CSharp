﻿namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int BASE_POWER = 80;

        public Druid(string name) : base(name, BASE_POWER)
        {
            
        }

        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {this.Name} healed for {this.Power}";
        }
    }
}
