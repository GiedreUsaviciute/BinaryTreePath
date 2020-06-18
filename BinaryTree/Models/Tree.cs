using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree.Models
{
    public class Tree
    {
        private Node _root;
        private int _maxBranchLength = 0;
        private Path _maxPath;


        public Tree(List<List<int>> pyramid)
        {
            _root = null;
            _maxBranchLength = pyramid.Count - 1;

            for (int i = 0; i < pyramid.Count; i++)
            {
                for (int j = 0; j < pyramid[i].Count; j++)
                {
                    InsertBranch(new Node { Value = pyramid[i][j], Level = i, Index = j });
                }
            }
        }

        public void InsertBranch(Node node)
        {
            if (_root == null)
            {
                _root = node;
                return;
            }

            Insert(_root, node);
        }

        private void Insert(Node root, Node node)
        {
            if (root.LeftChild == null)
            {
                if (ValidateNode(root, node)) root.LeftChild = CopyNode(node);
            }
            else if (root.RightChild == null)
            {
                if (ValidateNode(root, node)) root.RightChild = CopyNode(node);
            }
            else if (root.Level < node.Level)
            {
                Insert(root.LeftChild, node);
                Insert(root.RightChild, node);
            }
        }

        public void FindMaxPath()
        {
            FindValidPath(_root, new List<Node>());

            if (_maxPath == null)
            {
                Console.WriteLine("No path found");
            }
            else
            {
                _maxPath.Display();
            }
        }

        private void FindValidPath(Node node, List<Node> path)
        {
            var previousNode = path.Count == 0 ? null : path?.Last();

            if (node == null && previousNode != null && previousNode.Level == _maxBranchLength)
            {
                var pathValue = path.Sum(node => node.Value);

                if (_maxPath == null || pathValue > _maxPath.Value)
                {
                    _maxPath = new Path { Steps = path, Value = pathValue };

                    return;
                }
            }

            if (node != null && (previousNode == null || previousNode?.Even != node.Even))
            {
                path.Add(node);

                FindValidPath(node.LeftChild, new List<Node>(path));
                FindValidPath(node.RightChild, new List<Node>(path));
            }
        }

        private static Node CopyNode(Node node)
        {
            return new Node { Value = node.Value, Index = node.Index, Level = node.Level };
        }

        private static bool ValidateNode(Node root, Node node)
        {
            return root.Level == node.Level - 1 && (root.Index == node.Index || root.Index == node.Index - 1);
        }
    }
}
