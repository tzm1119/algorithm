using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.DynamicPrograming
{
    /// <summary>
    /// 获取最小组合的货币数
    /// </summary>
    public class P3_MinCoins
    {
        public int MinCoins(int[] arr,int aim)
        {
            if (arr==null||arr.Length==0||aim<0)
            {
                return -1;
            }

            return process(arr, 0, aim);

            
        }
        /// <summary>
        /// 暴力递归写法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="rest"></param>
        /// <returns></returns>
        public int process(int[] arr,int i,int rest)
        {
            if (i==arr.Length)
            {
                return rest == 0 ? 0 : -1;
            }
            int res = -1;
            for (int k = 0; arr[i]*k<=rest; k++)
            {
                int next = process(arr, i + 1, rest - k * arr[i]);
                if (next!=-1)
                {
                    res = res == -1 ? next + k : Math.Min(res, next + k);
                }
            }
            return res;
        }

        /// <summary>
        /// 动态规划优化写法
        /// </summary>
        /// <returns></returns>
        public int MinCoins2(int[] arr,int aim)
        {
            if (arr==null||arr.Length==0||aim<0)
            {
                return -1;
            }
            int N = arr.Length;
            int[,] dp = new int[N + 1, aim + 1];
            for (int col = 1; col <= aim; col++)
            {
                dp[N, col] = -1;
            }
            for (int i = N-1; i >=0; i--)
            {
                for (int rest = 0; rest <= aim; rest++)
                {
                    dp[i, rest] = -1;
                    if (dp[i+1,rest]!=-1)
                    {
                        dp[i, rest] = dp[i + 1, rest];
                    }
                    if (rest-arr[i]>=0&&dp[i,rest-arr[i]]!=-1)
                    {
                        if (dp[i,rest]==-1)
                        {
                            dp[i, rest] = dp[i, rest - arr[i]] + 1;
                        }
                        else
                        {
                            dp[i, rest] = Math.Min(dp[i, rest], dp[i, rest - arr[i] + 1]);
                        }
                    }
                }
            }
            return dp[0, aim];
        }
    }
}
