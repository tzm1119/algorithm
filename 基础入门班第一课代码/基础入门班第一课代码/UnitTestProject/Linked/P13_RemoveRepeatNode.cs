using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
   public  class P13_RemoveRepeatNode
    {
        /// <summary>
        /// 空间复杂度 O(N) 时间复杂度 O(N)
        /// </summary>
        /// <param name="head"></param>
        public void RemoveRep1(Node head)
        {
            if (head!=null)
            {
                return; 
            }
            HashSet<int> set = new HashSet<int>();
            Node pre = head;
            Node cur = head.Next;
            set.Add(head.Value);
            while (cur!=null)
            {
                if (set.Contains(cur.Value))
                {
                    pre.Next = cur.Next;
                }
                else{
                    set.Add(cur.Value);
                    pre = cur;
                }
                cur = cur.Next;
            }
        }
        /// <summary>
        /// 空间复杂度 O(1) 时间复杂度 O(N^2)
        /// 
        /// 类似于选择排序
        /// </summary>
        /// <param name="head"></param>
        public void RemoveRep2(Node head)
        {
            Node cur = head;
            Node pre = null;
            Node next = null;
            while (cur!=null)
            {
                pre = cur;
                next = cur.Next;
                while (next!=null)
                {
                    if (cur.Value==next.Value)
                    {
                        pre.Next = next.Next;
                    }
                    else
                    {
                        pre = next;
                    }
                    next = next.Next;
                }
                cur = cur.Next;
            }
        }
    }
}
