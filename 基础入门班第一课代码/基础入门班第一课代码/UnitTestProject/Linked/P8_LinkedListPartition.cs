using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Linked
{
   public  class P8_LinkedListPartition
    {
        public Node ListPartition1(Node head,int pivot)
        {
            if (head==null)
            {
                return head;
            }
            Node cur = head;
            int i = 0;
            while (cur!=null)
            {
                i++;
                cur = cur.Next;
            }
            Node[] nodeArr = new Node[i];
            i = 0;
            cur = head;
            for (i = 0; i < nodeArr.Length; i++)
            {
                nodeArr[i] = cur;
                cur = cur.Next;
            }
            ArrPartition(nodeArr, pivot);

            for (i = 1; i < nodeArr.Length; i++)
            {
                nodeArr[i - 1].Next = nodeArr[i];
            }
            nodeArr[i - 1].Next = null;
            return nodeArr[0];
        }

        public void ArrPartition(Node[] nodeArr,int pivot)
        {
            int small = -1;
            int big = nodeArr.Length;
            int index = 0;
            while (index!=big)
            {
                if (nodeArr[index].Value<pivot)
                {
                    Swap(nodeArr, ++small, index++);
                }
                else if (nodeArr[index].Value==pivot)
                {
                    index++;
                }
                else
                {
                    Swap(nodeArr, --big, index);
                }
            }
        }

        public void Swap(Node[] arr,int a,int b)
        {
            Node tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

        public Node ListPartition2(Node head,int pivot)
        {
            Node sH = null;//小的头
            Node sT = null;//小的尾
            Node eH = null;//相等的头
            Node eT = null;//相等的尾
            Node bH = null;//大的头
            Node bT = null;//大的尾
            Node next = null;//下一个节点
            //所有节点分进三个链表中
            while (head!=null)
            {
                next = head.Next;
                head.Next = null; 
                if (head.Value<pivot)
                {
                    if (sH==null)
                    {
                        sH = head;
                        sT = head;
                    }
                    else
                    {
                        sT.Next = head;
                        sT = head;
                    }
                }
                else if (head.Value==pivot)
                {
                    if (eH==null)
                    {
                        eH = head;
                        eT = head;
                    }
                    else
                    {
                        eT.Next = head;
                        eT = head;
                    }
                }
                else
                {
                    if (bH==null)
                    {
                        bH = head;
                        bT = head;
                    }
                    else
                    {
                        bT.Next = head;
                        bT = head;
                    }
                }
                head = head.Next;
            }
            //小的相等的连接
            if (sT!=null)
            {
                sT.Next = eH;
                eT = eT == null ? sT : eT;
            }
            //所有的重新连接
            if (eT!=null)
            {
                eT.Next = bH;
            }
            return sH != null ? sH : eH != null ? eH : bH;

        }
    }
}
