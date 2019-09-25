namespace ImageFileChecker.HeaderCheckers
{
    /// <summary>
    /// File header checker for PNG files
    /// </summary>
    public class PngHeaderChecker : FileHeaderComparer, IFileHeaderChecker
    {
        /// <summary>
        /// The expected header for PNG (jpg) files
        /// </summary>
        private readonly byte?[] _expectedHeader = new byte?[] { 137, 80, 78, 71, 13, 10, 26, 10 };

        public byte?[] HeaderSignature { get { return _expectedHeader; } }

        public bool IsMatch(byte[] fileBytes)
        {
            return base.CompareHeader(_expectedHeader, fileBytes);
        }
    }
}
