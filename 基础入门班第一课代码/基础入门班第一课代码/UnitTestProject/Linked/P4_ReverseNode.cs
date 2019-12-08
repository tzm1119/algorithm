using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P4_ReverseNode
    {
        /// <summary>
        /// 我的写法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node Reverse(Node head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }
            Node cur = head;
            Node next = cur.Next;
            cur.Next = null;
            while (next != null)
            {
                head = next;
                Node last = next.Next;
                next.Next = cur;
                next = last;
            }
            return head;
        }

        /// <summary>
        /// 书上的写法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node Reverse2(Node head)
        {
            Node pre = null;
            Node next = null;
            while (head != null)
            {
                next = head.Next;
                head.Next = pre;
                pre = head;
                head = next;
            }
            return head;
        }
        /// <summary>
        /// 反转双向链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public DoubleNode ReverseDoubleNode(DoubleNode head)
        {
            DoubleNode pre = null;
            DoubleNode next = null;
            while (head!=null)
            {
                next = head.Next;

                head.Next = pre;
                head.Last = next;

                pre = head;
                head = next;
            }
            return head;
        }
    }
}
