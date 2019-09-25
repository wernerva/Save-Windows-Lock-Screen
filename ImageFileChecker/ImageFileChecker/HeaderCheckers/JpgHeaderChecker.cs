namespace ImageFileChecker.HeaderCheckers
{
    /// <summary>
    /// File header checker for JPEG (jpg) files
    /// </summary>
    public class JpgHeaderChecker : FileHeaderComparer, IFileHeaderChecker
    {
        /// <summary>
        /// The expected header for JPEG (jpg) files. The null values should be skipped during comparison.
        /// </summary>
        private readonly byte?[] _expectedHeader = new byte?[] { 255, 216, 255, 224, null, null, 74, 70, 73, 70, 0 };

        public byte?[] HeaderSignature { get { return _expectedHeader; } }

        public bool IsMatch(byte[] fileBytes)
        {
            return base.CompareHeader(_expectedHeader, fileBytes);
        }
    }
}
