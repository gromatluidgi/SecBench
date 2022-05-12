using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SecBench.Domain.Entities.Files
{
    public class FileTree<TFile>
        where TFile : class, IFileItem
    {
        private readonly TFile _file;
        private readonly List<FileTree<TFile>> _children = new List<FileTree<TFile>>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="file"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FileTree(TFile file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));
            _file = file;
        }

        public FileTree<TFile>? Parent { get; private set; }

        public bool IsRoot => Parent == null;

        public TFile File => _file!;

        public ReadOnlyCollection<FileTree<TFile>> Children
        {
            get { return _children.AsReadOnly(); }
        }

        public FileTree<TFile> AddChild(TFile file)
        {
            var node = new FileTree<TFile>(file) { Parent = this };
            _children.Add(node);
            return node;
        }

        /// <summary>
        /// For each value execute <see cref="AddChild(TFile)"/>.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public FileTree<TFile>[] AddChildren(params TFile[] values)
        {
            return values.Select(AddChild).ToArray();
        }

        public bool RemoveChild(FileTree<TFile> node)
        {
            return _children.Remove(node);
        }

        /// <summary>
        /// Traverse any descendant recursively. Be aware of potential stack overflow exception if the
        /// tree is large and deeply nested.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="stopVisiting"></param>
        public virtual void Traverse(Action<FileTree<TFile>, TFile> action, bool stopVisiting = false)
        {
            action(this, File);
            foreach (var child in _children) {
                if (stopVisiting) break;
                child.Traverse(action, stopVisiting);
            }
        }

        /// <summary>
        /// Extract any descendant node from this tree and returns
        /// a O(N) list.
        /// </summary>
        /// <returns>flattened tree.</returns>
        public IEnumerable<TFile> Flatten()
        {
            return new[] { File }.Concat(_children.SelectMany(x => x.Flatten()));
        }

        public FileTree<TFile>? SearchNode(FileTree<TFile> node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            FileTree<TFile> findTree = null!;
            Traverse((tree, file) =>
            {
                if (file.Equals(node.File))
                {
                    findTree = tree;
                }
            }, findTree == null);
            return findTree;
        }

        public static List<TFile> FlattenMerge(FileTree<TFile> source, FileTree<TFile> target)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (target == null) throw new ArgumentNullException(nameof(target));

            var flattenTarget = target.Flatten().ToList();
            foreach (TFile item in source.Flatten())
            {
                var match = flattenTarget.Any((f) => f.Equals(item));
                if (match) continue;
                flattenTarget.Add(item);
            }

            return flattenTarget;
        }
    }
}
