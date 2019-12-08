using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
   public  class P12_ReverseKNode
    {
        /// <summary>
        /// 每k个节点之间 进行逆序
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public Node ReverseKNode1(Node head,int k)
        {
            if (k<2)
            {
                return head;
            }
            Stack<Node> stack = new Stack<Node>();
            Node newHead = head;
            Node cur = head;
            Node pre = null;
            Node next = null;
            while (cur!=null)
            {
                next = cur.Next;
                stack.Push(cur);
                if (stack.Count==k)
                {
                    pre = Resign1(stack, pre, next);
                    newHead = newHead == head ? cur : newHead;
                }
                cur = next;
            }
            return newHead;
        }

        public Node Resign1(Stack<Node> stack,Node left,Node right)
        {
            Node cur = stack.Pop();
            if (left!=null)
            {
                left.Next = cur;
            }
            Node next = null;
            while (stack.Count!=0)
            {
                next = stack.Pop();
                cur.Next = next;
                cur = next;
            }
            cur.Next = right;
            return cur;
        }

        /// <summary>
        /// 不用栈 省空间的写法
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public Node ReverseKNode2(Node head, int k)
        {
            if (k<2)
            {
                return head;
            }
            Node cur = head;
            Node start = null;
            Node pre = null;
            Node next = null;
            int count = 1;
            while (cur!=null)
            {
                next = cur.Next;
                if (count==k)
                {
                    start = pre == null ? head : pre.Next;
                    head = pre == null ? cur : head;
                    Resign2(pre, start, cur, next);
                    pre = start;
                    count = 0;
                }
                count++;
                cur = next;
            }
            return head;
        }

        public void Resign2(Node left,Node start,Node end,Node right)
        {
            Node pre = start;
            Node cur = start.Next;
            Node next = null;
            while (cur!=right)
            {
                next = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = next;
            }
            if (left != null)
            {
                left.Next = end;
            }
            start.Next = right;
        }
    }
}
