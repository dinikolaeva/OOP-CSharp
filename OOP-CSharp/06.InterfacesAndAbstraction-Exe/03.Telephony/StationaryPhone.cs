using System.Linq;

namespace _03.Telephony
{
    public class StationaryPhone : ICall
    {
        public string Calling(string number)
        {
            if (number.All(char.IsDigit))
            {
                return $"Dialing... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }
    }
}
