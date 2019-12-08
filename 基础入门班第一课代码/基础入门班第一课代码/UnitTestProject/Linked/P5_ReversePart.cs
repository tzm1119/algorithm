using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P5_ReversePart
    {
        public Node ReversePart(Node head, int start, int end)
        {
            if (head == null || start > end||start<1)
            {
                return head;
            }

            Node node1 = head;
            //要反转的前一个节点
            Node fPre = null;
            //要反转的后一个节点
            Node tPos = null;
            int len = 0;
            while (node1!=null)
            {
                len++;
                fPre = len == start - 1 ? node1 : fPre;
                tPos = len == end + 1 ? node1 : tPos;
                node1 = node1.Next;
            }
            //是否越界
            if (end>len)
            {
                return head;
            }
            //是否换头
            node1 = fPre == null ? head : fPre;
            Node node2 = node1.Next;
            node1.Next = tPos;
            Node next = null;
            while (node2!=tPos)
            {
                next = node2.Next;
                node2.Next = node1;
                node1 = node2;
                node2 = next;
            }
            if (fPre!=null)
            {
                fPre.Next = node1;
                return head;
            }
            return node1;

        }
    }
}
