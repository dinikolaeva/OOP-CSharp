namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int INITIAL_SIZE = 5;
        private const int INCREASES_SIZE = 2;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = INITIAL_SIZE;
        }

        public override void Eat()
        {
            this.Size += INCREASES_SIZE;
        }
    }
}
