using System.Collections.Generic;
using System.IO;

namespace ImageFileChecker.FileRetrievers
{
    public class PhysicalOrMappedDriveFileRetriever : IFileRetriever
    {
        public IEnumerable<string> GetFiles(string path)
        {
            if (!Directory.Exists(path)) return new string[0];

            var files = Directory.GetFiles(path);

            return files;
        }
    }
}
