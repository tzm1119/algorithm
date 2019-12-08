using System;
using System.Collections.Generic;
using System.Text;

namespace test.Sort
{
    public class PopSort : ISort
    {
        public int[] Sort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return arr;
            }
            
            for (int i = 0; i < arr.Length; i++)
            {
                //让最后一个数，变成是最大的
                for (int j = 0; j < arr.Length-i-1; j++)
                {
                    if (arr[j]>arr[j+1])
                    {
                        Swaper.Swap(arr, j, j + 1);
                    }
                }
            }
            return arr;
        }
    }
}