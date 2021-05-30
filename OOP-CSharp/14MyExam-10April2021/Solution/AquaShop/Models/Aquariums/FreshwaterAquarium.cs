namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        public const int CONST_CAPACITY = 50;

        public FreshwaterAquarium(string name) 
            : base(name, CONST_CAPACITY)
        {
        }
    }
}
