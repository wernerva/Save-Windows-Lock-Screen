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

            OnMessageEmited($"Checking source path: {path}");

            // No use in continuing if the source directory does not exist...
            if (!Directory.Exists(path))
            {
                OnMessageEmited("Path not found.");
                return;
            }

            // Get the path to the current user's My Pictures folder
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            // We'll be saving the images to their own folder within the user's My Pictures folder so append the path...
            savePath += @"\Windows Lock Screens";

            OnMessageEmited($"Checking destination path: {savePath}");

            // Create the save directory if it doesn't exist
            Directory.CreateDirectory(savePath);


            OnMessageEmited("Checking for image files...");

            // Go fetch the files. We're only interrested in the Desktop wallpapers which have a width of 1090 (I've made an assumption here... watch it bite me...)
            IEnumerable<ImageFile> imageFiles = new Checker().CheckPhysicalPath(path).Where(i => i.Width == 1920);

            OnMessageEmited($"Found {imageFiles.Count()}");
            
            foreach (var imageFile in imageFiles)
            {
                // build up the new file name for copying
                string fileName = $"{imageFile.FileName}.{imageFile.ImageType.ToString().ToLower()}";
                string fullFileName = $"{savePath}\\{fileName}";

                // if the file exists, skip copying
                if (File.Exists(fullFileName))
                {
                    OnMessageEmited($"{fileName} already exists. Skipping...");
                    continue;
                }

                OnMessageEmited($"Copying {fileName}");

                // copy to the save directory
                File.Copy(imageFile.FullPath, fullFileName);
            }

            OnMessageEmited("Done");
        }

        protected virtual void OnMessageEmited(string message)
        {
            EventHandler<string> handler = MessageEmitted;
            handler?.Invoke(this, message);
        }
    }
}
