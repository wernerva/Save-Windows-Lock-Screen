namespace ImageFileChecker
{
    /// <summary>
    /// The image formats that the checker can identify
    /// </summary>
    public enum ImageFormatEnum
    {
        /// <summary>
        /// Used when an a file is not a known image type
        /// </summary>
        Unknown,
        /// <summary>
        /// Join photgraphic expert group (JPEG)
        /// </summary>
        JPG,
        /// <summary>
        /// Graphics interchange format
        /// </summary>
        GIF,
        /// <summary>
        /// Bitmap
        /// </summary>
        BMP,
        /// <summary>
        /// Portable network graphics
        /// </summary>
        PNG,
        /// <summary>
        /// Tag image file format
        /// </summary>
        TIFF
    }
}
