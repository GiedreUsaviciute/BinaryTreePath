using BinaryTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var pyramid = CreatePyramid();

            if (pyramid == null)
                throw new Exception("Pyramid not found");

            var binaryTree = new Tree(pyramid);

            binaryTree.FindMaxPath();

            Console.ReadLine();
        }

        private static List<List<int>> CreatePyramid()
        {
            var pyramid = new List<List<int>>();

            pyramid.Add(new List<int> { 1 });
            pyramid.Add(new List<int> { 8, 9 });
            pyramid.Add(new List<int> { 1, 5, 9 });
            pyramid.Add(new List<int> { 4, 5, 2, 3 });

            return pyramid;
        }
    }
}
