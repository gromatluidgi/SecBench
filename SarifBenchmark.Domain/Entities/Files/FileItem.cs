using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.Entities.Files
{
    public class FileItem : IFileItem
    {
        public FileItem()
        {

        }

        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsDirectory { get; set; }

        public bool Equals(IFileItem other)
        {
            return other.Name == Name && other.Path == Path;
        }
    }
}
