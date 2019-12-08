using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.QueueStack
{
    /// <summary>
    /// 生成数组的 窗口最大值数组
    /// </summary>
    public class P7_MaxWindow
    {
        public int[] GetMaxWindow(int[] arr,int w)
        {
            if (arr==null||w<1||arr.Length<w)
            {
                return null;
            }
            LinkedList<int> qMax = new LinkedList<int>();
            int[] resArr = new int[arr.Length - w + 1];
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                while (qMax.Count!=0&&arr[qMax.Last.Value]<=arr[i])
                {
                    qMax.RemoveLast();
                }
                qMax.AddLast(i);
                if (qMax.First.Value==i-w)
                {
                    qMax.RemoveFirst();
                }
                if (i>=w-1)
                {
                    resArr[index++] = arr[qMax.First.Value];
                }
            }
            return resArr;
        }
    }
}
