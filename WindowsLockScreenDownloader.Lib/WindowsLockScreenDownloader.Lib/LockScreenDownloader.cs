using ImageFileChecker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsLockScreenDownloader.Lib
{
    public class LockScreenDownloader
    {
        public event EventHandler<string> MessageEmitted;

        /// <summary>
        /// Checks a Windows 10 OS for the lock screen images that Windows automatically downloads and copies them to a folder under the user's My Pictures 
        /// </summary>
        public void DownloadLockScreenImages()
        {
            // Get the path to the Windows lock screens for the current user
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path += @"\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";

            OnMessageEmited("Checking that path to lock screens exists...");

            // No use in continuing if the source directory does not exist...
            if (!Directory.Exists(path))
            {
                OnMessageEmited("Checking that path to lock screens exists...");
                return;
            }

            // Get the path to the current user's My Pictures folder
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            // We'll be saving the images to their own folder within the user's My Pictures folder so append the path...
            savePath += @"\Windows Lock Screens";

            // Create the save directory if it doesn't exist
            Directory.CreateDirectory(savePath);

            // Go fetch the files. We're only interrested in the Desktop wallpapers which have a width of 1090 (I've made an assumption here... watch it bite me...)
            IEnumerable<ImageFile> imagefiles = new Checker().CheckPhysicalPath(path).Where(i => i.Width == 1920);

            foreach (var imageFile in imagefiles)
            {
                // build up the new file name for copying
                string fileName = $"{savePath}\\{imageFile.FileName}.{imageFile.ImageType.ToString().ToLower()}";

                // if the file exists, skip copying
                if (File.Exists(fileName))
                {
                    continue;
                }

                // copy to the save directory
                File.Copy(imageFile.FullPath, fileName);
            }
        }

        protected virtual void OnMessageEmited(string message)
        {
            EventHandler<string> handler = MessageEmitted;
            handler?.Invoke(this, message);
        }
    }
}
