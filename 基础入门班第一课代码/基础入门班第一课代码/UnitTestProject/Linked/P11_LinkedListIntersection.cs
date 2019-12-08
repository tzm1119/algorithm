using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P11_LinkedListIntersection
    {
        /// <summary>
        /// 获取链表的相交节点
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        public Node GetIntersection(Node head1,Node head2)
        {
            if (head1==null||head2==null)
            {
                return null;
            }

            //获取入环节点
            Node loop1 = getLoopNode(head1);
            Node loop2 = getLoopNode(head2);
            //两个链表都无环
            if (loop1==null&&loop2==null)
            {
                return noLoop(head1, head2);
            }
            //都有环
            else if (loop1!=null&&loop2!=null)
            {
                return bothLoop(head1, loop1, head2, loop2);
            }
            return null;
        }

        /// <summary>
        /// 获取链表的入环节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node getLoopNode(Node head)
        {
            if (head == null || head.Next == null || head.Next.Next == null)
            {
                return null;
            }
            Node n1 = head.Next;
            Node n2 = head.Next.Next;
            while (n1 != n2)
            {
                if (n2.Next == null || n2.Next.Next == null)
                {
                    return null;
                }
                n2 = n2.Next.Next;
                n1 = n1.Next;
            }
            n2 = head;
            while (n1!=n2)
            {
                n1 = n1.Next;
                n2 = n2.Next;
            }
            return n1;
        }

        /// <summary>
        /// 判断两个无环链表是佛相交
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        public Node noLoop(Node head1,Node head2)
        {
            if (head1==null||head2==null)
            {
                return null;
            }
            Node cur1 = head1;
            Node cur2 = head2;
            int n = 0;
            while (cur1.Next!=null)
            {
                n++;
                cur1 = cur1.Next;
            }
            while (cur2.Next!=null)
            {
                n--;
                cur2 = cur2.Next;
            }
            if (cur1!=cur2)
            {
                return null;
            }
            cur1 = n > 0 ? head1 : head2;
            cur2 = cur1 == head1 ? head2 : head1;
            while (n!=0)
            {
                n--;
                cur1 = cur1.Next;
            }
            while (cur1!=cur2)
            {
                cur1 = cur1.Next;
                cur2 = cur2.Next;
            }
            return cur1;
        }
        
        /// <summary>
        /// 两个有环链表的交点
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="loop1"></param>
        /// <param name="head2"></param>
        /// <param name="loop2"></param>
        /// <returns></returns>
        public Node bothLoop(Node head1,Node loop1,Node head2,Node loop2)
        {
            Node cur1 = null;
            Node cur2 = null;
            if (loop1==loop2)
            {
                cur1 = head1;

                cur2 = head2;
                int n = 0;
                while (cur1!=loop1)
                {
                    n++;
                    cur1 = cur1.Next;
                }
                while (cur2!=loop2)
                {
                    n--;
                    cur2 = cur2.Next;
                }
                cur1 = n > 0 ? head1 : head2;
                cur2 = cur1 == head1 ? head2 : head2;
                n = Math.Abs(n);
                while (n!=0)
                {
                    n--;
                    cur1 = cur1.Next;
                }
                while (cur1!=cur2)
                {
                    cur1 = cur1.Next;
                    cur2 = cur2.Next;
                }
                return cur1;

            }
            else
            {
                cur1 = loop1.Next;
                while (cur1!=loop1)
                {
                    if (cur1==loop2)
                    {
                        return loop1;
                    }
                    cur1 = cur1.Next;
                }
                return null;
            }
        }
    }
}
