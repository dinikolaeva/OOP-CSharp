using System;
using System.Text;

namespace _01.ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            decimal length = decimal.Parse(Console.ReadLine());
            decimal width = decimal.Parse(Console.ReadLine());
            decimal height = decimal.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Surface Area - {box.GetSurfaceArea():f2}");
                sb.AppendLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
                sb.AppendLine($"Volume - {box.GetVolume():f2}");
                Console.WriteLine(sb.ToString().TrimEnd());
            }
            catch (Exception exc)
            {

                Console.WriteLine(exc.Message);
            }
        }
    }
}
