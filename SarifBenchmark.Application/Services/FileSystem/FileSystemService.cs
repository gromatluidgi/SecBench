using SecBench.Domain.Entities.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecBench.Application.Services.FileSystem
{
    public class FileSystemService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public FileTree<FileItem> BuildFileTree(string basePath)
        {
            DirectoryInfo rootDir = CanExploreDirectory(basePath);
            FileItem rootFileItem = FileItemFromDirectoryInfo(rootDir);
            FileTree<FileItem> fileTree = new FileTree<FileItem>(rootFileItem);
            RecursivelyTraverseDirectories(rootDir, fileTree);
            return fileTree;
        }

        public static int CountFileTreeNodes(FileTree<FileItem> tree)
        {
            int count = 0;
            tree.Traverse((_, __) => count++);
            return count;
        }

        /// <summary>
        /// Create a new instance of <see cref="FileItem"/> from <see cref="DirectoryInfo"/>.
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns>new instance of <see cref="FileItem"/>.</returns>
        public FileItem FileItemFromDirectoryInfo(DirectoryInfo directoryInfo)
        {
            return new FileItem()
            {
                Name = directoryInfo.Name,
                Path = directoryInfo.FullName,
                IsDirectory = true,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public FileItem FileItemFromFileInfo(FileInfo fileInfo)
        {
            return new FileItem()
            {
                Name = fileInfo.Name,
                Path = fileInfo.FullName,
                IsDirectory = false,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public DirectoryInfo CanExploreDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) throw new FileNotFoundException();
            return new DirectoryInfo(directoryPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentDirectory"></param>
        /// <param name="fileTree"></param>
        internal void RecursivelyTraverseDirectories(DirectoryInfo parentDirectory, FileTree<FileItem> fileTree)
        {
            // Iterate tought all sub-directories
            foreach (DirectoryInfo directoryInfo in parentDirectory.GetDirectories())
            {
                fileTree.AddChild(FileItemFromDirectoryInfo(directoryInfo));
                RecursivelyTraverseDirectories(directoryInfo, fileTree);
            }

            // Iterate tought all files of current directory
            foreach(FileInfo fileInfo in parentDirectory.GetFiles("*.*"))
            {
                fileTree.AddChild(FileItemFromFileInfo(fileInfo));
            }
        }

    }
}
