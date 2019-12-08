using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P18_InsertNum
    {
        /// <summary>
        /// 向循环有序 单链表中 插入新节点，仍保持有序
        /// </summary>
        /// <returns></returns>
        public Node InsertNum(Node head,int num)
        {
            Node node = new Node(num);
            if (head==null)
            {
                node.Next = node;
                return node;
            }
            Node pre = head;
            Node cur = head.Next;
            while (cur!=head)
            {
                if (pre.Value<=num && cur.Value>=num)
                {
                    break;
                }
                pre = cur;
                cur = cur.Next;
            }
            pre.Next = node;
            node.Next = cur;
            return head.Value < num ? head : node;
        }
    }
}
