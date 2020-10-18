using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Blink
{
    class CapsLockControl
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
        const byte CapsLock = 0x14;

        public static void ActionCapsLock()
        {
            keybd_event(CapsLock, 0x45, KEYEVENTF_EXTENDEDKEY | 0, (UIntPtr)0);
            keybd_event(CapsLock, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
        }
        /*
         * проверка работоспособности как-то работает из C++
        public void Start()
        {
            while (true)
            {
                if (Console.CapsLock)
                {
                    Console.WriteLine("Caps Lock key is OFF.");
                    keybd_event(CapsLock, 0x45, KEYEVENTF_EXTENDEDKEY | 0, (UIntPtr)0);
                    keybd_event(CapsLock, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
                }
                else
                {
                    Console.WriteLine("Caps Lock key is ON.");
                    keybd_event(CapsLock, 0x45, KEYEVENTF_EXTENDEDKEY | 0, (UIntPtr)0);
                    keybd_event(CapsLock, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }*/
    }
}
