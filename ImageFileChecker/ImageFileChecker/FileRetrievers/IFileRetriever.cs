using System.Collections.Generic;

namespace ImageFileChecker.FileRetrievers
{
    /// <summary>
    /// Interface for a class that will retrieve files
    /// </summary>
    public interface IFileRetriever
    {
        /// <summary>
        /// Method for retrieving file names from a path
        /// </summary>
        /// <param name="path">The path to check</param>
        /// <returns>An enumerable list of file names</returns>
        IEnumerable<string> GetFiles(string path);
    }
}
