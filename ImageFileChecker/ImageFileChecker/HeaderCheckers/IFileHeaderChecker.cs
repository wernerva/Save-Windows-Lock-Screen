namespace ImageFileChecker.HeaderCheckers
{
    /// <summary>
    /// Interface for a file header checker
    /// </summary>
    public interface IFileHeaderChecker
    {
        /// <summary>
        /// The header signature represented in byte array format. May contain null values
        /// </summary>
        byte?[] HeaderSignature { get; }
        
        /// <summary>
        /// Method for determining whether the header matches the given file's header
        /// </summary>
        /// <param name="fileBytes">The file to check in byte array format</param>
        /// <returns>True if the header matches, else false.</returns>
        bool IsMatch(byte[] fileBytes);
    }
}
