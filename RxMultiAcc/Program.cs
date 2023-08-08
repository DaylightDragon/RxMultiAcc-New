using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RxMultiAcc {
    class Program {
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void Main(string[] args) {
            using (Mutex mutex = new Mutex(true, "ROBLOX_singletonMutex")) {
                if (!mutex.WaitOne(TimeSpan.Zero, true)) {
                    Console.WriteLine("Another instance of this application is already running or you've started roblox before launching this\nExiting in 5 seconds");
                    Thread.Sleep(5000);
                    return;
                }

                Console.WriteLine("Crearead a mutex successfully");
                ShowWindow(GetConsoleWindow(), SW_HIDE);

                while (true) {
                    Thread.Sleep(int.MaxValue);
                }
            }
        }
    }
}
