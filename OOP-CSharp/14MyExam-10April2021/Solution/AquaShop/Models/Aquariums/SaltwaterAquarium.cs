namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        public const int CONST_CAPACITY = 25;

        public SaltwaterAquarium(string name) 
            : base(name, CONST_CAPACITY)
        {
        }
    }
}
