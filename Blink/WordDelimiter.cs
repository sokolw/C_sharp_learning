using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Blink
{
    class WordDelimiter : Morse
    {
        public void SendMessage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
