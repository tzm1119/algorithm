using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    /// <summary>
    /// 约瑟夫环问题
    /// </summary>
    public class P6_JosephusKill
    {
        public Node Kill(Node head, int m)
        {
            if (head == null || m < 1)
            {
                return head;
            }
            //last为head的前一个节点
            Node last = head;
            while (last.Next != head)
            {
                last = last.Next;
            }
            int count = 0;
            while (head != last)
            {
                if (++count == m)
                {
                    last.Next = head.Next;
                    count = 0;
                }
                else
                {
                    last = last.Next;
                }
                head = last.Next;
            }
            return head;
        }

        public Node Kill2(Node head, int m)
        {
            if (head == null || head.Next==head||m < 1)
            {
                return head;
            }
            Node cur = head.Next;
            int len = 1;
            while (cur != null)
            {
                cur = cur.Next;
                len++;
            }
            //last为head的前一个节点
            int index = 0;

            for (int i = 1; i < len; i++)
            {
                index = (index + m) % (i + 1);
            }

            while (--index>0)
            {
                head = head.Next;
            }
            head.Next = head;
            return head;

        }

        public Node Kill3(Node head, int m)
        {
            if (head == null || head.Next == head || m < 1)
            {
                return head;
            }
            Node cur = head.Next;
            int len = 1;
            while (cur != null)
            {
                cur = cur.Next;
                len++;
            }
            len = GetLive(len, m);

            return head;

        }

        private int GetLive(int i,int m)
        {
            if (i==1)
            {
                return 1;
            }
            return (GetLive(i - 1, m) + m - 1) % i + 1;
        }
    }
}
