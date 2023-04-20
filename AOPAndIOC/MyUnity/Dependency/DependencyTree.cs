using System;
using System.Collections.Generic;
using System.Linq;

namespace MyUnity.Dependency
{
    public class DependencyTree<T> where T : class
    {
        private List<TreeNode<T>> _allNodes;

        public DependencyTree(T root)
        {
            Root = new TreeNode<T>(root);
            _allNodes = new List<TreeNode<T>> { Root };
        }

        public TreeNode<T> Root { get; private set; }

        public void AddNode(T parent, T child)
        {
            var parentNode = _allNodes.FirstOrDefault(node => node.Parent == parent);
            if (parentNode == null)
            {
                throw new ArgumentException("parent is not in current dependency tree", "parent");
            }

            var childNode = _allNodes.FirstOrDefault(node => node.Parent == child);
            if (childNode == null)
            {
                childNode = new TreeNode<T>(child);
                _allNodes.Add(childNode);
            }

            if (!parentNode.ChildNodes.Contains(childNode))
            {
                parentNode.ChildNodes.Add(childNode);
            }
        }

        public void Traverse(Action<TreeNode<T>> operation)
        {
            List<TreeNode<T>> traversedNodes = new List<TreeNode<T>>();
            Traverse(Root, operation, traversedNodes);
        }

        private void Traverse(TreeNode<T> node, Action<TreeNode<T>> operation, List<TreeNode<T>> traversedNodes)
        {
            if (traversedNodes.Contains(node))
            {
                return;
            }
            operation(node);
            traversedNodes.Add(node);
            node.ChildNodes.ForEach(childNode => Traverse(childNode, operation, traversedNodes));
        }

        public List<T> SortByDependencyDepth()
        {
            List<TreeNode<T>> sortedNodes = new List<TreeNode<T>>();
            for (int i = 0; i < _allNodes.Count; i++)
            {
                bool hasLeaf = false;
                foreach (var node in _allNodes.Reverse<TreeNode<T>>())
                {
                    if (sortedNodes.Contains(node))
                    {
                        continue;
                    }
                    Traverse(node,
                        currentTraverseNode =>
                        {
                            if (currentTraverseNode.ChildNodes.All(childNode => sortedNodes.Contains(childNode)))
                            {
                                hasLeaf = true;
                                sortedNodes.Add(currentTraverseNode);
                            }
                        },
                        new List<TreeNode<T>>(sortedNodes));
                }
                if (!hasLeaf)
                {
                    throw new Exception("cycle dependency detected");
                }
                if (sortedNodes.Count == _allNodes.Count)
                {
                    break;
                }
            }
            return sortedNodes.Select(node => node.Parent).ToList();
        }
    }
}
