using System;

namespace TestData
{
    /// <summary>
    /// 必须自己写 大规模，小样本测试用例
    /// </summary>
    public class ArrayGenerator
    {
        public static int[] GetTestArray(int Length, int minValue, int maxValue)
        {
            int[] res = new int[Length];
            var rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < Length; i++)
            {
                res[i] = rand.Next(minValue, maxValue + 1);
            }
            return res;
        }
        public static int[] GetRandomTestArray()
        {

            var rand = new Random((int)DateTime.Now.Ticks);
            int Length = rand.Next(5, 100);
            int minValue = rand.Next(-100, 50);
            int maxValue = rand.Next(minValue, rand.Next(50, 3000));
            int[] res = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                res[i] = rand.Next(minValue, maxValue + 1);
            }
            return res;
        }
        public static bool ArrayEqual(int[] a1, int[] a2)
        {
            if (a1 == a2)
            {
                return true;
            }
            if (a1.Length != a2.Length)
            {
                return false;
            }
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class NumberGenerator
    {
        /// <summary>
        /// 获取随机奇数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomEven(int min = 1, int max = 100)
        {
            Random random = new Random();
            int res = 0;
            do
            {
                res = random.Next(min, max + 1);
            } while (res % 2 == 0);
            return res;
        }
        /// <summary>
        /// 获取随机偶数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomOdd(int min = 1, int max = 100)
        {
            Random random = new Random();
            int res = 0;
            do
            {
                res = random.Next(min, max + 1);
            } while (res % 2 == 1);
            return res;
        }
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomNumber(int min = 1, int max = 100)
        {
            Random random = new Random();
            int res = 0;
            res = random.Next(min, max + 1);
            return res;
        }
    }
}
