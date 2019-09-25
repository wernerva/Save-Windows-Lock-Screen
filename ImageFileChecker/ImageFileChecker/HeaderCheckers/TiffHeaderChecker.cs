namespace ImageFileChecker.HeaderCheckers
{
    /// <summary>
    /// File header checker for TIFF files
    /// </summary>
    public class TiffHeaderChecker : FileHeaderComparer, IFileHeaderChecker
    {
        /// <summary>
        /// The expected header for TIFF files
        /// </summary>
        private readonly byte?[] _expectedHeader = new byte?[] { 73, 73, 42 };

        public byte?[] HeaderSignature { get { return _expectedHeader; } }

        public bool IsMatch(byte[] fileBytes)
        {
            return base.CompareHeader(_expectedHeader, fileBytes);
        }
    }
}
