using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Engine
    {
        public void Run()
        {
            var phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var sites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            foreach (var phone in phoneNumbers)
            {
                if (phone.Length == 10)
                {
                    ICall call = new Smartphone();
                    Console.WriteLine(call.Calling(phone));
                }
                else
                {
                    ICall dialing = new StationaryPhone();
                    Console.WriteLine(dialing.Calling(phone));
                }
            }

            foreach (var site in sites)
            {
                IBrowse browse = new Smartphone();
                Console.WriteLine(browse.Browsing(site));
            }
        }
    }
}
