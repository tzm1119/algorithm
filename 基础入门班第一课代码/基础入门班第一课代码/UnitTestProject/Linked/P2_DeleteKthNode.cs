using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    /// <summary>
    /// 删除链表的倒数第k个节点
    /// </summary>
    public class P2_DeleteKthNode
    {
        Node DeleteNode(Node head,int k)
        {
            if (head==null||k < 1)
            {
                return head;
            }
            Node cur = head;
            while (cur != null)
            {
                k--;
                cur = cur.Next;
            }
            if (k==0)
            {
                head = head.Next;
            }
            if (k<0)
            {
                cur = head;
                while (++k!=0)
                {
                    cur = cur.Next;
                }
                cur.Next = cur.Next.Next;
            }
            return head;
        }

        DoubleNode DeleteNode(DoubleNode head, int k)
        {
            if (head==null||k<1)
            {
                return head;
            }
            DoubleNode cur = head;
            while (cur!=null)
            {
                cur = cur.Next;
                k--;
            }
            //删除第一个节点
            if (k==0)
            {
                head = head.Next;
                head.Last = null;
            }
            if (k<0)
            {
                cur = head;
                while (++k!=0)
                {
                    cur = cur.Next;
                }
                var newNext = cur.Next.Next;
                cur.Next = newNext;
                if (newNext!=null)
                {
                    newNext.Last = cur;
                }
            }
            return head;
        }
    }
}
