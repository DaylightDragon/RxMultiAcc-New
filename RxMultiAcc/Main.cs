using System;
using System.Threading;
using static RbxMultiAcc.Winapi;
using static RbxMultiAcc.Texts;

namespace RbxMultiAcc
{
    internal static class MainClass
    {
        private static readonly String mutexName = "ROBLOX_singletonMutex";
        private static int delayOnError = 5000;

        [STAThread]
        public static void Main()
        {
            using (Mutex mutex = new Mutex(true, mutexName))
            {
                if (!mutex.WaitOne(TimeSpan.Zero, true))
                {
                    AllocConsole();
                    ShowWindow(GetConsoleWindow(), SW_SHOW);
                    Console.WriteLine(TranslateMessageCouldntCreateMutex());
                    Thread.Sleep(delayOnError);
                    return;
                }

                Console.WriteLine(TranslateMessageSuccessfullyCreatedMutex());

                while (true)
                {
                    Thread.Sleep(int.MaxValue);
                }
            }
        }
    }
}