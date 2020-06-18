using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree.Models
{
    public class Path
    {
        public int Value { get; set; }
        public List<Node> Steps { get; set; }

        public void AddStep(Node node)
        {
            Steps.Add(node);
            Value += node.Value;
        }

        public void Display()
        {
            Console.WriteLine($"Max Sum: {Value}");
            Console.WriteLine($"Path: {string.Join(',', Steps.Select(s => s.Value.ToString()))}");
        }
    }
}