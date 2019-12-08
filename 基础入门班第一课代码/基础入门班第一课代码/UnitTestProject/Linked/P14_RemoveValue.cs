using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P14_RemoveValue
    {
        /// <summary>
        /// 使用额外空间 删除等于指定数值的 节点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public Node RemoveValue1(Node head,int num)
        {
            Stack<Node> stack = new Stack<Node>();
            while (head!=null)
            {
                if (head.Value!=num)
                {
                    stack.Push(head);
                }
                head = head.Next;
            }
            while (stack.Count!=0)
            {
                stack.Peek().Next = head;
                head = stack.Pop();
            }
            return head;
        }


        public Node RemoveValue2(Node head,int num)
        {
            while (head!=null)
            {
                if (head.Value!=num)
                {
                    break;
                }
            }
            Node pre = head;
            Node cur = head;
            while (cur!=null)
            {
                if (cur.Value==num)
                {
                    pre.Next = cur.Next;
                }
                else
                {
                    pre = cur;
                }
                cur = cur.Next;
            }
            return head;
        }


    }
}
