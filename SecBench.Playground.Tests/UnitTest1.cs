using SecBench.Application.Services.FileSystem;
using SecBench.Domain.Entities.Files;
using SecBench.Domain.Entities.Violations;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecBench.Playground.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void BuildTree()
        {
            // Arrange
            var appDataDir = Environment.CurrentDirectory;
            var fileSystemService = new FileSystemService();

            // Act
            var result = fileSystemService.BuildFileTree(appDataDir);

            Assert.NotNull(result);
        }

        [Fact]
        public void Traverse()
        {
            // Arrange
            var appDataDir = Environment.CurrentDirectory;
            var fileSystemService = new FileSystemService();
            var tree = fileSystemService.BuildFileTree(appDataDir);

            // Act
            tree.Traverse((_, __) => { });
        }

        [Fact]
        public void Flatten()
        {
            // Arrange
            var appDataDir = Environment.CurrentDirectory;
            var fileSystemService = new FileSystemService();
            var tree = fileSystemService.BuildFileTree(appDataDir);

            // Act
            var result = tree.Flatten();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void FlattenMerge()
        {
            // Arrange
            var appDataDir = Environment.CurrentDirectory;
            var fileSystemService = new FileSystemService();
            var treeOne = fileSystemService.BuildFileTree(appDataDir);
            var treeTwo = fileSystemService.BuildFileTree(appDataDir);
            treeTwo.RemoveChild(treeTwo.Children[0]);

            // Act
            var result = FileTree<FileItem>.FlattenMerge(treeOne, treeTwo);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(treeOne.Children.Count+1, result.Count);
        }

        [Fact]
        public void SearchNode()
        {
            // Arrange
            var appDataDir = Environment.CurrentDirectory;
            var fileSystemService = new FileSystemService();
            var tree = fileSystemService.BuildFileTree(appDataDir);
            var searchedTree = new FileTree<FileItem>(new FileItem()
            {
                Name = "net6.0",
                Path = "C:\\_dev\\SarifBenchmark\\SecBench.Playground.Tests\\bin\\Debug\\net6.0",
                IsDirectory = true,
            });

            // Act
            var result = tree.SearchNode(searchedTree);

            // Assert
            Assert.NotNull(result);
            Assert.True(searchedTree.File.Equals(result!.File));
        }

        [Fact]
        public void CountNodes()
        {
            // Arrange
            var tree = new FileTree<FileItem>(new FileItem()
            {
                Name = "net6.0",
                Path = "C:\\_dev\\SarifBenchmark\\SecBench.Playground.Tests\\bin\\Debug\\net6.0",
                IsDirectory = true,
            });

            tree.AddChildren(
                new FileItem(),
                new FileItem()
            )[0].AddChild(new FileItem());

            // Act
            var result = FileSystemService.CountFileTreeNodes(tree);

            // Assert
            Assert.Equal(result, 4);
        }
    }
}