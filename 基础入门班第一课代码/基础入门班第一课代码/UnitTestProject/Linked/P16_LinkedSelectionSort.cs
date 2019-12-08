using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P16_LinkedSelectionSort
    {
        /// <summary>
        /// 实现选择排序
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node SelectionSort(Node head)
        {
            Node tail = null;//排序部分的尾部
            Node cur = head;//未排序部分的头部
            Node smallPre = null;//最小节点的前一个节点
            Node small = null;//最小节点
            while (cur!=null)
            {
                small = cur;
                smallPre = GetSmallestPreNode(cur);
                if (smallPre!=null)
                {
                    small = smallPre.Next;
                    smallPre.Next = small.Next;
                }
                cur = cur == small ? cur.Next : cur;
                if (tail==null)
                {
                    head = small;
                }
                else
                {
                    tail.Next = small;
                }
                tail = small;
            }
            return head;
        }

        public Node GetSmallestPreNode(Node head)
        {
            Node smallPre = null;
            Node small = head;
            Node pre = head;
            Node cur = head.Next;
            while (cur!=null)
            {
                if (cur.Value<small.Value)
                {
                    smallPre = pre;
                    small = cur;
                }
                pre = cur;
                cur = cur.Next;
            }
            return smallPre;
        }
    }
}
