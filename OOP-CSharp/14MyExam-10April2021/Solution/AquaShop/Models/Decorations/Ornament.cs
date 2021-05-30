namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        public const int CONST_COMFORT = 1;
        public const decimal CONST_PRICE = 5;

        public Ornament() 
            : base(CONST_COMFORT, CONST_PRICE)
        {
        }
    }
}
