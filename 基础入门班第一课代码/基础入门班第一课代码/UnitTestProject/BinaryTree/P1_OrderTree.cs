using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.BinaryTree
{
    /// <summary>
    /// 二叉树 先中后序遍历 递归和非递归
    /// </summary>
    public class P1_OrderTree
    {
        #region 递归
        public void preOrderRecur(Node head)
        {
            if (head == null)
            {
                return;
            }
            Console.WriteLine($"{head.Value} ");
            preOrderRecur(head.Left);
            preOrderRecur(head.Right);
        }

        public void inOrderRecur(Node head)
        {
            if (head == null)
            {
                return;
            }
            inOrderRecur(head.Left);
            Console.WriteLine($"{head.Value} ");
            inOrderRecur(head.Right);
        }

        public void posOrderRecur(Node head)
        {
            if (head == null)
            {
                return;
            }
            posOrderRecur(head.Left);
            posOrderRecur(head.Right);
            Console.WriteLine($"{head.Value} ");
        }
        #endregion

        #region 非递归
        public void preOrderUnRecur(Node head)
        {
            if (head != null)
            {
                Stack<Node> stack = new Stack<Node>();
                stack.Push(head);
                while (stack.Count != 0)
                {
                    head = stack.Pop();
                    Console.WriteLine(head.Value);
                    if (head.Right != null)
                    {
                        stack.Push(head.Right);
                    }
                    if (head.Left != null)
                    {
                        stack.Push(head.Left);
                    }
                }
            }
        }

        public void inOrderUnRecur(Node head)
        {
            if (head != null)
            {
                Stack<Node> stack = new Stack<Node>();
                while (stack.Count != 0)
                {
                    if (head != null)
                    {
                        stack.Push(head);
                        head = head.Left;
                    }
                    else
                    {
                        head = stack.Pop();
                        Console.WriteLine(head.Value);
                        head = head.Right;
                    }
                }
            }
        }

        public void posOrderUnRecur(Node head)
        {
            if (head != null)
            {
                Stack<Node> s1 = new Stack<Node>();
                Stack<Node> s2 = new Stack<Node>();
                s1.Push(head);
                while (s1.Count != 0)
                {
                    head = s1.Pop();
                    s2.Push(head);
                    if (head.Left != null)
                    {
                        s1.Push(head.Left);
                    }
                    if (head.Right != null)
                    {
                        s1.Push(head.Right);
                    }
                }
                while (s2.Count != 0)
                {
                    Console.WriteLine(s2.Pop().Value);
                }
            }
        }

        public void posOrderUnRecur2(Node head)
        {
            if (head != null)
            {
                Stack<Node> stack = new Stack<Node>();
                stack.Push(head);
                Node c = null;
                while (stack.Count != 0)
                {
                    c = stack.Peek();
                    if (c.Left != null && head != c.Left && head != c.Right)
                    {
                        stack.Push(c.Left);
                    }
                    else if (c.Right != null && head != c.Right)
                    {
                        stack.Push(c.Right);
                    }
                    else
                    {
                        Console.WriteLine(stack.Pop().Value);
                        head = c;
                    }
                }
            }
        }
        #endregion

    }
}
