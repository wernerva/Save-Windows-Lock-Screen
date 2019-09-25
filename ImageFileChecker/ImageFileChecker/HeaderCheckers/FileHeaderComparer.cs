namespace ImageFileChecker.HeaderCheckers
{
    /// <summary>
    /// Base class for file header comparers
    /// </summary>
    public abstract class FileHeaderComparer
    {
        /// <summary>
        /// Compares a file's header to with a given file header
        /// </summary>
        /// <param name="expectedHeader">The header to check for in byte array format. Null values in this array will be skipped during comparison</param>
        /// <param name="fileBytes">The file content in byte array</param>
        /// <returns>True if the given file's header matches the expected header</returns>
        protected bool CompareHeader(byte?[] expectedHeader, byte[] fileBytes)
        {
            // Ensure that there is something to check.
            if (expectedHeader == null || fileBytes == null || fileBytes.Length < expectedHeader.Length) return false;

            for (int i = 0; i < expectedHeader.Length; i++)
            {
                byte? b = expectedHeader[i];

                // If this byte in the signature is null the comparison for this byte will be skipped.
                if (b.HasValue && b != fileBytes[i]) return false;
            }

            // Since there were no explicit mismatches we return true.
            return true;
        }
    }
}
