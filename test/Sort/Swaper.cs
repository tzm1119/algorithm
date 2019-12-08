using System;
using System.Collections.Generic;
using System.Text;

namespace test.Sort
{

    /// <summary>
    /// 吃草问题 只能吃4的次数
    /// 
    /// 1 2 3 4 5 6 7 8
    /// 1 0 1 1 0 1 0 
    /// 
    /// 打表法 在输入 和 输出 都很简单的情况下好用，例如 输入一个n，输出一个n
    /// 
    /// 预处理
    /// 
    /// 预处理矩阵
    /// 
    /// 生成辅助 矩阵，记住 矩阵特征的信息，在之后 使用的时候，直接用
    /// </summary>
    public class Swaper
    {
        public static void Swap(int[] arr,int i,int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        /// <summary>
        /// 异或 可以理解为 无进位加法
        /// 
        /// 性质:
        /// N^N=0 
        /// 0^N=N 加法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void Swap2(int[] arr, int i, int j)
        {
            if (i!=j)
            {
                arr[i] = arr[i] ^ arr[j];
                arr[j] = arr[i] ^ arr[j];
                arr[i] = arr[i] ^ arr[j];
            }
        }
    }
}
