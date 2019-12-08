using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.QueueStack
{
    /// <summary>
    /// 求arr中 max(arr[i...j])-min(arr[i...j]) < num 满足条件的子数组个数
    /// </summary>
    public class P10_SubMaxMinLessThanNum
    {
        public int GetNum(int[] arr,int num)
        {
            if (arr==null||arr.Length==0||num<0)
            {
                return 0;
            }
            LinkedList<int> qMin = new LinkedList<int>();
            LinkedList<int> qMax = new LinkedList<int>();
            int i = 0;
            int j = 0;
            int res = 0;
            while (i<arr.Length)
            {
                while (j<arr.Length)
                {
                    if (qMin.Count==0||qMin.Last.Value!=j)
                    {
                        while (qMin.Count!=0&&arr[qMin.Last.Value]>=arr[j])
                        {
                            qMin.RemoveLast();
                        }
                        qMin.AddLast(j);
                        while (qMax.Count!=0&&arr[qMax.Last.Value]<=arr[j])
                        {
                            qMax.RemoveLast();
                        }
                        qMax.AddLast(j);
                    }
                    if (arr[qMax.First.Value]-arr[qMin.First.Value]<=num)
                    {
                        break;
                    }
                    j++;
                }
                res += j - 1;
                if (qMin.First.Value==i)
                {
                    qMin.RemoveFirst();
                }
                if (qMax.First.Value==i)
                {
                    qMax.RemoveFirst();
                }
                i++;
            }
            return res;
        }
    }
}
