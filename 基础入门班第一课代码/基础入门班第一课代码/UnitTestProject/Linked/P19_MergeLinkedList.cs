using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P19_MergeLinkedList
    {
        /// <summary>
        /// 合并两个有序链表
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        public Node Merge(Node head1,Node head2)
        {
            if (head1==null||head2==null)
            {
                return head1 == null ? head2 : head1;
            }
            Node head = head1.Value < head2.Value ? head1:head2;
            Node cur1 = head == head1 ? head1 : head2;
            Node cur2 = head == head1 ? head2 : head1;
            Node pre = null;
            Node next = null;
            while (cur1!=null&&cur2!=null)
            {
                if (cur1.Value<cur2.Value)
                {
                    pre = cur1;
                    cur1 = cur1.Next;
                }
                else
                {
                    next = cur2.Next;
                    pre.Next = cur2;
                    cur2.Next = cur1;
                    pre = cur2;
                    cur2 = next;
                }
            }
            pre.Next = cur1 == null ? cur2 : cur1;
            return head;

        }
    }
}
