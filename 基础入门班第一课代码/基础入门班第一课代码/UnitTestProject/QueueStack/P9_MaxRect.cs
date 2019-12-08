using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.QueueStack
{
    /// <summary>
    /// 矩阵中只有0,1.求最大全为1的子矩阵中1的数量
    /// </summary>
    public class P9_MaxRect
    {
        public int MaxRecSize(int[][] map)
        {
            if (map==null||map.Length==0||map[0].Length==0)
            {
                return 0;
            }
            int maxArea = 0;
            int[] height = new int[map[0].Length];
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    height[j] = map[i][j] == 0 ? 0 : height[j] + 1;
                }
                maxArea = Math.Max(maxArea, maxRecFromBottom(height));
            }
            return maxArea;
        }

        public int maxRecFromBottom(int[] height)
        {
            if (height==null||height.Length==0)
            {
                return 0;
            }
            int maxArea = 0;
            Stack<int> sk = new Stack<int>();
            for (int i = 0; i < height.Length; i++)
            {
                while (sk.Count!=0&&height[i]<=height[sk.Peek()])
                {
                    int j = sk.Pop();
                    int k = sk.Count == 0 ? -1 : sk.Peek();
                    int curArea = (i - k - 1) * height[j];
                    maxArea = Math.Max(maxArea, curArea);
                }
                sk.Push(i);
            }
            while (sk.Count!=0)
            {
                int j = sk.Pop();
                int k = sk.Count == 0 ? -1 : sk.Peek();
                int curArea = (height.Length - k - 1) * height[j];
                maxArea = Math.Max(maxArea, curArea);
            }
            return maxArea;
        }
    }
}
