using BinaryTree.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        //base data for pyramid when file not provided
        private static List<List<int>> CreatePyramid()
        {
            var pyramid = new List<List<int>>();

            pyramid.Add(new List<int> { 1 });
            pyramid.Add(new List<int> { 8, 9 });
            pyramid.Add(new List<int> { 1, 5, 9 });
            pyramid.Add(new List<int> { 4, 5, 2, 3 });

            return pyramid;
        }

        //reads file and converts it into pyramid matrix
        public static List<List<int>> CreatePyramid(string filePath)
        {
            var pyramid = new List<List<int>>();

            if (string.IsNullOrWhiteSpace(filePath)) 
                return pyramid;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                pyramid.Add(line.Split(' ').ToList().Select(int.Parse).ToList());
            }

            return pyramid;
        }
    }
}
