using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.Aggregates.Analyzers
{
    public readonly struct Executable
    {
        public Executable(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public string Path { get; }

        public string Name { get; }

        /// <summary>
        /// Set executable path from given absolute directory path.
        /// </summary>
        /// <param name="absolutePath">Absolute path of executable.</param>
        /// <returns></returns>
        public static Executable FromAbsolutePath(string absolutePath, string fileName)
        {
            var path = string.Format("{0}{1}", absolutePath, fileName);
            return new Executable(path, fileName);
        }

        /// <summary>
        /// Set executable path to relative path from application
        /// current domain directory.
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        public static Executable FromDomainRelativePath(string relativePath, string fileName)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string file = System.IO.Path.Combine(currentDir, relativePath);
            string path = ValidateDomainRelativePath(currentDir, System.IO.Path.GetFullPath(file));

            return new Executable(path, fileName);
        }

        internal static string ValidateDomainRelativePath(string currentDir, string absolutePath)
        {
            if (absolutePath.StartsWith(currentDir))
            {
                return absolutePath;
            }
            throw new InvalidOperationException("Absolute path must contains current directory path.");
        }
    }
}
