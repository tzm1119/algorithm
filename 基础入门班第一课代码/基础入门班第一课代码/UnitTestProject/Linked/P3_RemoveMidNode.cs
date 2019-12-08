using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
   public  class P3_RemoveMidNode
    {
        /// <summary>
        /// 简单的遍历方法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node RemoveMidNode(Node head)
        {
            if (head==null||head.Next==null)
            {
                return head;
            }
            if (head.Next.Next.Next!=null)
            {
                return head.Next;
            }
            int k = 0;
            Node cur = head;
            while (cur!=null)
            {
                k++;
            }
            cur = head;
            int step = k / 2;
            while (step>0)
            {
                cur = cur.Next;
                step--;
            }
            cur.Next = cur.Next.Next;
            return head;
        }
        /// <summary>
        /// 快慢指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node RemoveMidNode2(Node head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }
            if (head.Next.Next == null)
            {
                return head.Next;
            }

            Node pre = head;
            Node last = pre.Next.Next;
            while (last.Next!=null&&last.Next.Next!=null)
            {
                pre = pre.Next;
                last = last.Next.Next;
            }
            pre.Next = pre.Next.Next;
            return head;
        }

        /// <summary>
        /// 删除第 a/b 个节点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public Node RemoveByRatio(Node head,int a,int b)
        {
            if (a<1||a>b)
            {
                return head;
            }
            int n = 0;
            Node cur = head;
            while (cur!=null)
            {
                cur = cur.Next;
                n++;
            }
            n = (int)Math.Ceiling((double)(a * n) / b);
            if (n == 1)
            {
                head = head.Next;
            }
            if (n>1)
            {
                cur = head;
                while (--n !=1)
                {
                    cur = cur.Next;
                }
                cur.Next = cur.Next.Next;
            }
            return head;

        }
    }
}
