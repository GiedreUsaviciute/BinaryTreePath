using System;
using System.Collections.Generic;
using System.Data;

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
                if (root.Level == node.Level - 1 && (root.Index == node.Index || root.Index == node.Index - 1)) root.LeftChild = node;
            }
            else if (root.RightChild == null)
            {
                if (root.Level == node.Level - 1 && (root.Index == node.Index || root.Index == node.Index - 1)) root.RightChild = node;
            }
            else
            {
                Insert(root.LeftChild, node);
                Insert(root.RightChild, node);
            }
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
