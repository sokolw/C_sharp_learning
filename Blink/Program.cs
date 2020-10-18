using System;
using System.Threading;

namespace Blink
{
    class Program
    {
        static void Main(string[] args)
        {
            BlinkMorse blinkMorse = new BlinkMorse();
            blinkMorse.Start();
        }
    }
}
