using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
    public class P17_RemoveNodeWired
    {
        /// <summary>
        /// 只知道head节点，而且还要删除head节点
        /// 
        /// 把后面的值 前移，然后删除后面的节点
        /// 
        /// 无法删除最后的节点
        /// </summary>
        /// <param name="head"></param>
        public void RemoveNodeWired(Node head)
        {
            if (head==null)
            {
                return;
            }
            Node next = head.Next;
            if (next==null)
            {
                throw new Exception("can not remove last node");
            }
            head.Value = next.Value;
            head.Next = next.Next;
        }
    }
}
