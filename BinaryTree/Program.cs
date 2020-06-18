using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var pyramid = new List<List<int>>();

            pyramid.Add(new List<int> { 1 });
            pyramid.Add(new List<int> { 8, 9 });
            pyramid.Add(new List<int> { 1, 5, 9 });
            pyramid.Add(new List<int> { 4, 5, 2, 3 });

            var binaryTree = new BinaryTree();

            for (int i = 0; i < pyramid.Count; i++)
            {
                for (int j = 0; j < pyramid[i].Count; j++)
                {
                    binaryTree.InsertBranch(new Node { Value = pyramid[i][j], Level = i, Index = j });
                }
            }


            Console.ReadLine();
        }
    }

    public class BinaryTree
    {
        private Node _root;
        int _maxBranchLength;


        public BinaryTree()
        {
            _root = null;
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
            else
            {
                Insert(root.LeftChild, node);
                Insert(root.RightChild, node);
            }
        }

        public void FindMaxPath()
        { 
        
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

    public class Node
    {
        public int Value { get; set; }
        public int Index { get; set; }
        public int Level { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
    }
}
