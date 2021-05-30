namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        public const int CONST_COMFORT = 5;
        public const decimal CONST_PRICE = 10;

        public Plant() 
            : base(CONST_COMFORT, CONST_PRICE)
        {
        }
    }
}
