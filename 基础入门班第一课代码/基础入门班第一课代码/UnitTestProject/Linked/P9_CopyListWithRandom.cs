using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    /// <summary>
    /// 复制含有随机指针的链表
    /// </summary>
    public class P9_CopyListWithRandom
    {
        /// <summary>
        /// 使用字典的写法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyList(Node head)
        {
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            Node cur = head;
            while (cur!=null)
            {
                map[cur] = new Node(cur.Value);
                cur = cur.Next;
            }
            cur = head;
            while (cur!=null)
            {
                map[cur].Next = map[cur.Next];
                map[cur].Rand = map[cur.Rand];
                cur = cur.Next;
            }
            return map[head];
        }
        /// <summary>
        /// 空间复杂度O(1)的写法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyList2(Node head)
        {
            if (head==null)
            {
                return null;
            }
            Node cur = head;
            Node next = null;
            //复制并连接每一个节点
            while (cur!=null)
            {
                next = cur.Next;
                cur.Next = new Node(cur.Value);
                cur.Next.Next = next;
                cur = next;
            }
            cur = head;
            Node curCopy = null;
            //设置复制节点的rand指针
            while (cur!=null)
            {
                next = cur.Next.Next;
                curCopy = cur.Next;
                curCopy.Rand = cur.Rand != null ? cur.Rand.Next : null;
                cur = next;
            }
            Node res = head.Next;
            cur = head;
            //拆分
            while (cur!=null)
            {
                next = cur.Next.Next;
                curCopy = cur.Next;
                cur.Next = next;
                curCopy.Next = next != null ? next.Next : null;
                cur = next;
            }
            return res;



        }
    }

}
