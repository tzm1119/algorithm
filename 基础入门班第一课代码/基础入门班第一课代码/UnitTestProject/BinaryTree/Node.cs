using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.BinaryTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int d)
        {
            Value = d;
        }
    }
}
