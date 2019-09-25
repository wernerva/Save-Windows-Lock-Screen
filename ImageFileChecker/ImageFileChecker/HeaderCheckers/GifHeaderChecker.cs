namespace ImageFileChecker.HeaderCheckers
{
    /// <summary>
    /// File header checker for GIF files
    /// </summary>
    public class GifHeaderChecker : FileHeaderComparer, IFileHeaderChecker
    {
        /// <summary>
        /// The expected header for GIF files
        /// </summary>
        private readonly byte?[] _expectedHeader = new byte?[] { 71, 73, 70 };

        public byte?[] HeaderSignature { get { return _expectedHeader; } }

        public bool IsMatch(byte[] fileBytes)
        {
            return base.CompareHeader(_expectedHeader, fileBytes);
        }
    }
}
