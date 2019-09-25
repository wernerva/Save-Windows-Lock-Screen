using ImageFileChecker.FileRetrievers;
using ImageFileChecker.HeaderCheckers;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ImageFileChecker
{
    /// <summary>
    /// Implementation of the IChecker interface for checking for image files
    /// </summary>
    public class Checker: IChecker
    {
        /// <summary>
        /// A dictionary of supported image file formats and the checker that can identify that format.
        /// </summary>
        private static Dictionary<ImageFormatEnum, IFileHeaderChecker> _headerChekers = new Dictionary<ImageFormatEnum, IFileHeaderChecker>()
        {
            { ImageFormatEnum.BMP, new BmpHeaderChecker() },
            { ImageFormatEnum.GIF, new GifHeaderChecker() },
            { ImageFormatEnum.JPG, new JpgHeaderChecker() },
            { ImageFormatEnum.PNG, new PngHeaderChecker() },
            { ImageFormatEnum.TIFF, new TiffHeaderChecker() }
        };

        private static IFileRetriever fileRetriever = new PhysicalOrMappedDriveFileRetriever();

        /// <summary>
        /// Checking a specified physical path for image files (non recursive)
        /// </summary>
        /// <param name="path">The fully qualified path to check</param>
        /// <returns>A collection of ImageFile objects that containins each found image file's details.</returns>
        public ICollection<ImageFile> CheckPhysicalPath(string path)
        {
            List<ImageFile> imageFiles = new List<ImageFile>();

            IEnumerable<string> filenames = fileRetriever.GetFiles(path);

            foreach (string filename in filenames)
            {
                byte[] fileBytes = File.ReadAllBytes(filename);
                ImageFormatEnum imgType = CheckHeader(fileBytes);

                if (imgType == ImageFormatEnum.Unknown) continue;

                using (var s = new MemoryStream(fileBytes))
                using (Bitmap img = new Bitmap(s))
                {
                    imageFiles.Add(new ImageFile()
                    {
                        Content = fileBytes,
                        FullPath = filename,
                        Heigth = img.Height,
                        ImageType = imgType,
                        FileName = new FileInfo(filename).Name,
                        Width = img.Width
                    });
                }
            }

            return imageFiles;
        }

        /// <summary>
        /// Checks a file to see if it matches any of the file formats known to this library
        /// </summary>
        /// <param name="fileBytes">The file content in byte array format</param>
        /// <returns>The image file format of the file</returns>
        private static ImageFormatEnum CheckHeader(byte[] fileBytes)
        {
            var imgType = ImageFormatEnum.Unknown;
            IFileHeaderChecker headerChecker;

            foreach (ImageFormatEnum key in _headerChekers.Keys)
            {
                headerChecker = _headerChekers[key];

                if (headerChecker.IsMatch(fileBytes))
                {
                    imgType = key;
                }
            }

            return imgType;
        }
    }
}
