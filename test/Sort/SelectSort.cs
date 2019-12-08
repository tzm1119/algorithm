using System;
using System.Collections.Generic;
using System.Text;

namespace test.Sort
{
    public class SelectSort : ISort
    {
        public int[] Sort(int[] arr)
        {
            if (arr==null||arr.Length<2)
            {
                return arr;
            }
            //依次保证0~i 有序
            for (int i = 0; i < arr.Length; i++)
            {
                //从i+1到最后，找到小的数，就放到i上，从而使i位置上为，i+1到最后的最小的一个数
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i]>arr[j])
                    {
                        Swaper.Swap(arr, i, j);
                    }
                }
            }
            return arr;
        }
    }
}
