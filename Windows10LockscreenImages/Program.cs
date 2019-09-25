using System;
using WindowsLockScreenDownloader.Lib;

namespace Windows10LockscreenImages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Copying Windows Lock Screens...");

            LockScreenDownloader lsd = new LockScreenDownloader();
            lsd.MessageEmitted += Lsd_MessageEmitted;
            lsd.DownloadLockScreenImages();

            Console.WriteLine("Done");

            for (int i = 5; i >= 0; i--)
            {
                Console.Write($"\rClosing in {i}");

                if (i > 0) System.Threading.Thread.Sleep(1000);
            }
        }

        private static void Lsd_MessageEmitted(object sender, string e)
        {
            Console.WriteLine(e);
        }
    }
}
