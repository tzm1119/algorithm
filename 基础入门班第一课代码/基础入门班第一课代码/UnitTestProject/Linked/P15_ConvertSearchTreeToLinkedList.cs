using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P15_ConvertSearchTreeToLinkedList
    {
        public Node Convert(Node head)
        {
            Queue<Node> queue = new Queue<Node>();
            inOrderToQueue(head, queue);
            if (queue.Count==0)
            {
                return head;
            }
            head = queue.Dequeue();
            Node pre = head;
            pre.Left = null;
            Node cur = null;
            while (queue.Count!=0)
            {
                cur = queue.Dequeue();
                pre.Right = cur;
                cur.Left = pre;
                pre = cur;
            }
            pre.Right = null;
            return head;
        }

        public void inOrderToQueue(Node head,Queue<Node> queue)
        {
            if (head==null)
            {
                return;
            }
            inOrderToQueue(head.Left, queue);
            queue.Enqueue(head);
            inOrderToQueue(head.Right, queue);
        }


        /// <summary>
        /// 利用递归 降低空间复杂度为 O(h) h为树的高度
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>

        public Node Convert2(Node head)
        {
            if (head==null)
            {
                return null;
            }
            return process(head).Start;
        }

        public ReturnType process(Node head)
        {
            if (head==null)
            {
                return new ReturnType(null, null);
            }
            ReturnType leftList = process(head.Left);
            ReturnType rightList = process(head.Right);
            if (leftList.End!=null)
            {
                leftList.End.Right = head;
            }
            head.Left = leftList.End;
            head.Right = leftList.Start;
            if (rightList.Start!=null)
            {
                rightList.Start.Left = head;
            }
            return new ReturnType(leftList.Start != null ? leftList.Start : head, rightList.End == null ? rightList.End: head);

        }

        public class ReturnType
        {
            public Node Start { get; set; }
            public Node End { get; set; }

            public ReturnType(Node s,Node e)
            {
                this.Start = s;
                this.End = e;
            }
        }
    }
}
