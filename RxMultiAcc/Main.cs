using System;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

using static RbxMultiAcc.Winapi;
using static RbxMultiAcc.Texts;
using RbxMultiAcc;

namespace RbxMultiAcc
{
    internal static class MainClass
    {
        private static readonly String mutexName = "ROBLOX_singletonMutex";
        private static int delayOnError = 5000;

        private static CancellationTokenSource cancellationTokenSource;

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

                TrayIcon trayIcon = new TrayIcon();
                trayIcon.Init();

                cancellationTokenSource = new CancellationTokenSource();
                Run(cancellationTokenSource.Token);

                Application.Run();
            }
        }

        private static void Run(CancellationToken token) {
            Task.Run(() => {
                while (!token.IsCancellationRequested) {
                    Thread.Sleep(100);
                }
            });
        }

        public static void ExitApplication() {
            cancellationTokenSource?.Cancel();
            Application.Exit();
        }
    }
}