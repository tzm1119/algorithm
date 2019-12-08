using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.QueueStack
{
    /// <summary>
    /// 返回数组 左侧和右侧最近的小于当前数的值
    /// </summary>
    public class P8_ArrayLeftRightMin
    {
        /// <summary>
        /// 暴力解法 N^2
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[,] easyWay(int[] arr)
        {
            int[,] res = new int[arr.Length,2];
            for (int i = 0; i < arr.Length; i++)
            {
                int leftMinIndex = -1;
                int rightMinIndex = -1;
                int cur = i - 1;
                while (cur>=0)
                {
                    if (arr[cur]<arr[i])
                    {
                        leftMinIndex = cur;
                        break;
                    }
                    cur--;
                }
                cur = i + 1;

                while (cur < arr.Length)
                {
                    if (arr[cur] < arr[i])
                    {
                        rightMinIndex = cur;
                        break;
                    }
                    cur++;
                }
                res[i, 0] = leftMinIndex;
                res[i, 1] = rightMinIndex;
            }
            return res;
        }

        /// <summary>
        /// 在无重复的数组中，找到每个位置 左侧和右侧距离最近的小于当前数的值
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[,] GetNearLessNoRepeat(int[] arr)
        {
            int[,] resArr = new int[arr.Length, 2];
            //要保证栈中的值严格递减
            Stack<int> sk = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                while (sk.Count!=0&&arr[sk.Peek()]>arr[i])
                {
                    int popIndex = sk.Pop();
                    int leftMinIndex = sk.Count == 0 ? -1 : sk.Peek();
                    resArr[popIndex, 0] = leftMinIndex;
                    resArr[popIndex, 1] = i;
                }
                sk.Push(i);
            }
            //清算栈中的剩余数据
            while (sk.Count!=0)
            {
                int popIndex = sk.Pop();
                int leftMinIndex = sk.Count == 0 ? -1 : sk.Peek();
                resArr[popIndex, 0] = leftMinIndex;
                resArr[popIndex, 1] = -1;
            }
            return resArr;
        }

        /// <summary>
        /// 在有重复的数组中，找到左右侧距离最近的且小于当前数的最小值
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[,] GetNearLess(int[] arr)
        {
            int[,] resArr = new int[arr.Length, 2];
            Stack<List<int>> sk = new Stack<List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                while (sk.Count!=0&&arr[sk.Peek()[0]]>arr[i])
                {
                    List<int> popList = sk.Pop();
                    int leftMinIndex = sk.Count == 0 ? -1 : sk.Peek()[sk.Peek().Count - 1];
                    foreach (var popI in popList)
                    {
                        resArr[popI,0] = leftMinIndex;
                        resArr[popI, 1] = i;
                    }
                }
                if (sk.Count!=0&&arr[sk.Peek()[0]]==arr[i])
                {
                    sk.Peek().Add(i);
                }
                else
                {
                    sk.Push(new List<int>
                    {
                        i
                    });
                }
            }
            while (sk.Count!=0)
            {
                var popList = sk.Pop();
                int leftMinIndex = sk.Count == 0 ? -1 : sk.Peek()[sk.Peek().Count - 1];
                foreach (var popI in popList)
                {
                    resArr[popI, 0] = leftMinIndex;
                    resArr[popI, 1] = -1;
                }
            }
            return resArr;
        }


    }
}
