using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P10_AddList
    {
        public Node AddList(Node head1, Node head2)
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();
            while (head1 != null)
            {
                s1.Push(head1.Value);
                head1 = head1.Next;
            }
            while (head2 != null)
            {
                s2.Push(head2.Value);
                head2 = head2.Next;
            }
            int ca = 0;
            int n1 = 0;
            int n2 = 0;
            int n = 0;
            Node node = null;
            Node pre = null;
            //只要 两个 有一个不是空 就继续
            while (s1.Count != 0 || s2.Count != 0)
            {
                n1 = s1.Count == 0 ? 0 : s1.Pop();
                n2 = s2.Count == 0 ? 0 : s2.Pop();
                n = n1 + n2 + ca;
                pre = node;
                node = new Node(n % 10);
                node.Next = pre;
                ca = n / 10;
            }
            if (ca == 1)
            {
                pre = node;
                node = new Node(1);
                node.Next = pre;
            }
            return node;
        }


        /// <summary>
        /// 省空间的写法，不用栈
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        public Node AddList2(Node head1, Node head2)
        {
            P4_ReverseNode reverse = new P4_ReverseNode();
            head1 = reverse.Reverse2(head1);
            head2 = reverse.Reverse2(head2);
            int ca = 0;
            int n1 = 0;
            int n2 = 0;
            int n = 0;
            Node c1 = head1;
            Node c2 = head2;
            Node node = null;
            Node pre = null;
            while (c1 != null || c2 != null)
            {
                n1 = c1 != null ? c1.Value : 0;
                n2 = c2 != null ? c2.Value : 0;
                n = n1 + n2 + ca;
                pre = node;
                node = new Node(n % 10);
                node.Next = pre;
                ca = n / 10;
                c1 = c1 != null ? c1.Next:null;
                c2 = c2 != null ? c2.Next : null;
                
            }
            if (ca==1)
            {
                pre = node;
                node = new Node(1);
                node.Next = pre;
            }
            reverse.Reverse2(head1);
            reverse.Reverse2(head2);
            return node;
        }
    }
}
