using System;

namespace myhomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine("Hello World! You random number it" + random.Next(1-3));
        }
    }
}
