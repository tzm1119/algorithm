using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.DynamicPrograming
{
    /// <summary>
    /// 最小路径和问题
    /// </summary>
    public class P2_MinSumPath
    {
        public int MinSumPath(int[][] m)
        {
            if (m==null||m.Length==0||m[0].Length==0)
            {
                return 0;
            }
            int row = m.Length;
            int col = m[0].Length;
            int[,] dp = new int[row, col];
            dp[0, 0] = m[0][0];
            for (int i = 1; i < row; i++)
            {
                dp[i, 0] = m[i][0];
            }
            for (int i = 1; i < col; i++)
            {
                dp[0, i] = m[0][i];
            }
            for (int i = 2; i < row; i++)
            {
                for (int j = 2; j < col; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + m[i][j];
                }
            }
            return dp[row - 1, col - 1];
        }

        /// <summary>
        /// 空间压缩写法
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int MinSumPath2(int[][] m)
        {
            if (m == null || m.Length == 0 || m[0].Length == 0)
            {
                return 0;
            }
            int row = m.Length;
            int col = m[0].Length;
            int more = Math.Max(row, col);
            int less = Math.Min(row, col);
            bool rowMore = more == row ? true : false;
            int[] arr = new int[less];
            arr[0] = m[0][0];
            for (int i = 1; i < less; i++)
            {
                arr[i] = arr[i - 1] + (rowMore ? m[0][i] : m[i][0]);
            }
            for (int i = 1; i < more; i++)
            {
                arr[0] = arr[0] + (rowMore ? m[i][0] : m[0][i]);
                for (int j = 1; j < less; j++)
                {
                    arr[j] = Math.Min(arr[j - 1], arr[j]) + (rowMore ? m[i][j] : m[j][i]);
                }
            }
            return arr[less - 1];
        }
    }
}
