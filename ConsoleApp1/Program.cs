using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new SimpleMathComponent.SimpleMath();
            var g = x.returnGeolocator();
            Console.WriteLine("Adding 5.5 + 6.5 ...");
            Console.WriteLine(x.add(5.5, 6.5).ToString());
        }
    }
}
