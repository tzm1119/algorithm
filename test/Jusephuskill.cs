using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestData;

namespace test
{
    /// <summary>
    /// 约瑟夫环问题
    /// </summary>
    public class Jusephuskill : ICanTest
    {
        /// <summary>
        /// 测试性能
        /// </summary>
        public void TestBigO()
        {
            float[] beishu = new float[] { 0.001f, 0.01f, 0.1f, 0.5f, 1, 5, 10, 100 };
            foreach (var item in beishu)
            {
                //约瑟夫环问题
                List<long> res1 = new List<long>();
                List<long> res2 = new List<long>();
                List<long> res3 = new List<long>();

                int n = 5000;
                int m = (int)(n * item);
                Program.PrintSplit();
                int times = 20;
                for (int i = m; i < m + times; i++)
                {

                    res1.Add(Watcher.PrintTime("我的最优方案", () =>
                   {
                       var r = GetLive4(n, i);
                       //Console.WriteLine(r);

                   }, false));

                    res2.Add(Watcher.PrintTime("老师的最优方案", () =>
                   {
                       var r = GetLive3(n, i);
                       //Console.WriteLine(r);


                   }, false));

                    res3.Add(Watcher.PrintTime("我的while与m有关的方案", () =>
                   {
                       var r = GetLive2(n, i);
                       //Console.WriteLine(r);

                   }, false));


                }

                Console.WriteLine($"n={n} m={m} 执行{times}次，平均时间分别为: 我的最优方案 {res1.Average()} ms 老师的最优方案 {res2.Average()} ms 我的while与m有关的方案 {res3.Average()} ms");
            }
        }

        public bool TestSuccess()
        {
            bool right = true;

            int n = 5000;
            int m = 100;
            Program.PrintSplit();
            int times = 200;
            for (int i = m; i < m + times; i++)
            {
                if (GetLive(n, m) != GetLiveCompare(n, m))
                {
                    right = false;
                    break;
                }
            }

            for (int i = m; i < m + times; i++)
            {
                if (GetLive2(n, m) != GetLiveCompare(n, m))
                {
                    right = false;
                    break;
                }
            }

            for (int i = m; i < m + times; i++)
            {
                if (GetLive3(n, m) != GetLiveCompare(n, m))
                {
                    right = false;
                    break;
                }
            }

            for (int i = m; i < m + times; i++)
            {
                if (GetLive4(n, m) != GetLiveCompare(n, m))
                {
                    right = false;
                    break;
                }
            }

            return right;

        }

        /// <summary>
        /// 获取最后剩下的人所在的序号，序号从1开始  O(N)
        /// </summary>
        /// <param name="l">启示的人数</param>
        /// <param name="m">m个数为一组报数</param>
        /// <returns></returns>
        public int GetLive(int l, int m)
        {
            int pre = 1;
            if (l > 1)
            {
                for (int i = 2; i <= l; i++)
                {
                    pre = pre + m;
                    if (pre > i)
                    {
                        //如果pre的最大值为i，如果pre可以整除i，则pre=i
                        //如果pre不能整除i,则pre=pre-pre /i * i 就可以得到 小于 i的 最接近i的合法的pre
                        pre = (pre % i == 0) ? i : pre % i;
                    }
                }
            }
            return pre;
        }
        /// <summary>
        /// 与m相关的 解法 O(N*M)
        /// </summary>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int GetLive2(int l, int m)
        {
            int pre = 1;
            if (l > 1)
            {
                for (int i = 2; i <= l; i++)
                {
                    pre = pre + m;
                    while (pre > i)
                    {
                        //如果pre的最大值为i，如果pre可以整除i，则pre=i
                        //如果pre不能整除i,则pre=pre-pre /i * i 就可以得到 小于 i的 最接近i的合法的pre
                        pre -= i;
                    }
                }
            }
            return pre;
        }

        /// <summary>
        /// 老师的方法 O(N)
        /// </summary>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public int GetLive3(int N, int M)
        {
            int num = 1;
            int live = 1;
            while (num < N)
            {
                live = (live + M - 1) % (++num) + 1;
            }
            return live;
        }

        /// <summary>
        /// 在老师方法基础上 常数级别改进 O(N)
        /// </summary>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public int GetLive4(int N, int M)
        {
            int num = 1;
            int live = 0;
            while (num < N)
            {
                live = (live + M) % (++num);
            }
            return live + 1;
        }

        public int GetLiveCompare(int l, int m)
        {
            var nexter = new Nexter(l);

            while (nexter.LastCount != 1)
            {
                nexter.Next(m);
                nexter.RemoveCurrent();
            }
            return nexter.Current;
        }


    }

    class Nexter
    {
        private int index = -1;

        private List<int> arr;
        public Nexter(int count)
        {
            arr = Enumerable.Range(1, count).ToList();
        }

        public int LastCount { get { return arr.Count; } }

        public int Current { get { return arr[0]; } }
        public void Next(int m)
        {
            for (int i = 0; i < m; i++)
            {
                NextOneStep();
            }
        }

        public void NextOneStep()
        {
            if (index >= arr.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }


        public void RemoveCurrent()
        {
            arr.RemoveAt(index);
            //索引前移
            if (index == 0)
            {
                index = arr.Count - 1;
            }
            else
            {
                index--;
            }
        }
    }
}
