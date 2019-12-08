using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    /// <summary>
    /// 判断链表回文
    /// </summary>
    public class P7_Palindrome
    {
        public bool IsPalindrome(Node head)
        {
            Stack<Node> sk = new Stack<Node>();
            Node cur = head;
            while (cur!=null)
            {
                sk.Push(cur);
                cur = cur.Next;
            }
            while (head!=null)
            {
                if (head.Value!=sk.Pop().Value)
                {
                    return false;
                }
                head = head.Next;
            }
            return true;
        }
        /// <summary>
        /// 优化后 压入一半
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome2(Node head)
        {
            if (head==null||head.Next==null)
            {
                return true;
            }
           
            Node cur = head;
            Node right = cur.Next;
            while (cur.Next != null&&cur.Next.Next!=null)
            {
                right = right.Next;
                cur = cur.Next.Next;
            }

            Stack<Node> sk = new Stack<Node>();
            while (right!=null)
            {
                sk.Push(right);
                right = right.Next;
            }
            while (sk.Count!=0)
            {
                if (head.Value!=sk.Pop().Value)
                {
                    return false;
                }
                head = head.Next;
            }
            return true;
        }
        /// <summary>
        /// 空间复杂度为 O(1)的写法，需要改变链表的结构
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome3(Node head)
        {

            if (head==null||head.Next==null)
            {
                return true;
            }
            Node n1 = head;
            Node n2 = head;
            while (n2.Next!=null&&n2.Next.Next!=null)
            {
                n1=n1.Next;
                n2 = n2.Next.Next;
            }
            n2 = n1.Next;
            n1.Next = null;
            Node n3 = null;
            while (n2!=null)
            {
                n3 = n2.Next;
                n2.Next = n1;
                n1 = n2;
                n2 = n3;
            }
            n3 = n1;
            n2 = head;
            bool res = true;
            while (n1!=null&&n2!=null)
            {
                if (n1.Value!=n2.Value)
                {
                    res = false;
                    break;
                }
                n1 = n1.Next;
                n2 = n2.Next;

            }
            n1 = n3.Next;

            n3.Next = null;
            while (n1!=null)
            {
                n2 = n1.Next;
                n1.Next = n3;
                n3 = n1;
                n1 = n2;
            }
            return
                 res;

        }

    }
}
