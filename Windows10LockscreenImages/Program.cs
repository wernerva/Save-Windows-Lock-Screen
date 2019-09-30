using System;
using WindowsLockScreenDownloader.Lib;

namespace Windows10LockscreenImages
{
    class Program
    {
        static void Main(string[] args)
        {
            int wait = TryGetWaitFromArgs(args);

            Console.WriteLine("Copying Windows Lock Screens...");

            LockScreenDownloader lsd = new LockScreenDownloader();
            lsd.MessageEmitted += Lsd_MessageEmitted;
            lsd.DownloadLockScreenImages();

            Console.WriteLine();

            for (int i = wait; i >= 0; i--)
            {
                Console.Write($"\rClosing in {i}");

                if (i > 0) System.Threading.Thread.Sleep(1000);
            }
        }

        private static void Lsd_MessageEmitted(object sender, string e)
        {
            Console.WriteLine(e);
        }

        private static int TryGetWaitFromArgs(string[] args)
        {
            int result = 0;

            if (args.Length == 0) return result;

            int waitIdx = Array.IndexOf(args, "-w");

            if (waitIdx > -1 && (args.Length - 1) >= (waitIdx + 1))
            {
                if (!int.TryParse(args[waitIdx + 1], out result) || result < 0) {
                    Console.WriteLine("Invalid value for wait. Expected a positive integer.");
                    result = 0;
                }
            }

            return result;
        }
    }
}
