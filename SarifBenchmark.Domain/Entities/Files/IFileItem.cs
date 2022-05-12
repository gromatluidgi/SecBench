using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.Entities.Files
{
    public interface IFileItem : IEquatable<IFileItem>
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsDirectory { get; set; }

    }
}
