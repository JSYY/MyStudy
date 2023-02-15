using System.Collections.Generic;

namespace MyUnity.Dependency
{
    public class TreeNode<T>
    {
        public TreeNode(T parent)
        {
            Parent = parent;
            ChildNodes = new List<TreeNode<T>>();
        }

        public T Parent { get; private set; }

        public List<TreeNode<T>> ChildNodes { get; private set; }
    }
}
