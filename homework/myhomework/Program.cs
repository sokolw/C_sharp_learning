using System;

namespace myhomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] arr = new int[5] {1,2,3,4,5};
            Console.WriteLine("Numbers between 1-5");
            foreach(int e in arr)
                Console.WriteLine(arr);
            Console.WriteLine("Hello World! You random number it" + random.Next(1-3));
        }
    }
}
