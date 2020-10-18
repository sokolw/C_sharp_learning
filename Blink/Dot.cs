using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Blink
{
    class Dot : Morse
    {
        public void SendMessage()
        {
            CapsLockControl.ActionCapsLock();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            CapsLockControl.ActionCapsLock();
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}
