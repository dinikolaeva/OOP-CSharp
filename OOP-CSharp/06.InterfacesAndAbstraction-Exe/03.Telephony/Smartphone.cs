using System.Linq;

namespace _03.Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        public string Calling(string number)
        {
            if (number.All(char.IsDigit))
            {
                return $"Calling... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }

        public string Browsing(string url)
        {
            if (!url.Any(char.IsDigit))
            {
                return $"Browsing: {url}!";
            }
            else
            {
                return "Invalid URL!";
            }
        }
    }
}
