namespace ImageFileChecker
{
    /// <summary>
    /// Represents an image file
    /// </summary>
    public class ImageFile
    {
        /// <summary>
        /// The fully qualified path of the image
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The filename of the image
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The type of the image file
        /// </summary>
        public ImageFormatEnum ImageType { get; set; }

        /// <summary>
        /// Image width in pixels
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Image height in pixels
        /// </summary>
        public int Heigth { get; set; }

        /// <summary>
        /// The cfile conent in byte array form
        /// </summary>
        public byte[] Content { get; set; }
    }
}
