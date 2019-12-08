using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P20_Relocate
    {
        /// <summary>
        /// 把链表分成两部分
        /// 
        /// L1 L2 L3 .....R1 R2 R3
        /// 
        /// 最后组合为 L1 R1 L2 R2....
        /// </summary>
        /// <param name="head"></param>
        public void Relocate(Node head)
        {
            if (head==null||head.Next==null)
            {
                return;
            }
            Node mid = head;
            Node right = head.Next;
            while (right.Next!=null&&right.Next.Next!=null)
            {
                mid = mid.Next;
                right = right.Next.Next;
            }
            right = mid.Next;
            mid.Next = null;

        }

        public void MergeLR(Node left,Node right)
        {
            Node next = null;
            while (left.Next!=null)
            {
                next = right.Next;
                right.Next = left.Next;
                left.Next = right;
                left = right.Next;
                right = next;
            }
            left.Next = right;
        }
    }
}
