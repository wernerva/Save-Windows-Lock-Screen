using System.Collections.Generic;

namespace ImageFileChecker
{
    /// <summary>
    /// Interface for checking for image files
    /// </summary>
    public interface IChecker
    {
        /// <summary>
        /// Method for checking a physical path for image files
        /// </summary>
        /// <param name="path">The fully qualified path to check</param>
        /// <returns>A collection of ImageFile objects that containins each found image file's details.</returns>
        ICollection<ImageFile> CheckPhysicalPath(string path);
    }
}
