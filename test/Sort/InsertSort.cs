using System;
using System.Collections.Generic;
using System.Text;

namespace test.Sort
{
    /// <summary>
    /// 插入排序 往前面插入
    /// </summary>
    public class InsertSort : ISort
    {
        public  int[] Sort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return arr;
            }
            //保证前0到i 有序
            for (int i = 0; i < arr.Length-1; i++)
            {
                //保证把 i+1 插入到前面合适的位置
                for (int j = i+1; j >0; j--)
                {
                    //后项比前项小，则交换
                    if (arr[j]<arr[j-1])
                    {
                        Swaper.Swap(arr, j, j - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return arr;
        }
    }

    public interface ISort
    {
        int[] Sort(int[] arr);
    }
}
