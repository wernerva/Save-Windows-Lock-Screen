namespace ImageFileChecker.HeaderCheckers
{
    /// <summary>
    /// File header checker for bitmap files
    /// </summary>
    public class BmpHeaderChecker : FileHeaderComparer, IFileHeaderChecker
    {
        /// <summary>
        /// The expected header for bitmap files
        /// </summary>
        private readonly byte?[] _expectedHeader = new byte?[] { 66, 77 };

        public byte?[] HeaderSignature { get { return _expectedHeader; } }

        public bool IsMatch(byte[] fileBytes)
        {
            return base.CompareHeader(_expectedHeader, fileBytes);
        }
    }
}
