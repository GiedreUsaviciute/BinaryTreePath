using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Models
{
    public class Node
    {
        public int Value { get; set; }
        public int Index { get; set; }
        public int Level { get; set; }
        public bool Even => Value % 2 == 0;
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
    }
}
