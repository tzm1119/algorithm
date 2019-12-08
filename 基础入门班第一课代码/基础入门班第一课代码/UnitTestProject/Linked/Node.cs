using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node Rand { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }


        public Node(int v)
        {
            this.Value = v;
        }
    }

    public class DoubleNode
    {
        public int Value { get; set; }
        public DoubleNode Next { get; set; }
        public DoubleNode Last { get; set; }

        public DoubleNode(int v)
        {
            this.Value = v;
        }
    }
}
