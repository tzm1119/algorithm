using System;
using System.Collections.Generic;
using System.Text;
using TestData;

namespace test
{
    /// <summary>
    /// 异或性质
    /// 
    /// 0^N=N ; N^N=0
    /// 
    /// 一组数中，只有一个数出现了奇数次，其他数都出现偶数次，求这个数是多少
    /// 一组数中，有两个数出现了奇数次，其他数都出现偶数次，求这个数是多少
    /// </summary>
    public class EvenTimesOddTimes : ICanTest
    {
        public void TestBigO()
        {
            Console.WriteLine("ok");
        }

        public bool TestSuccess()
        {
            bool success = true;
           
            for (int i = 10; i < 500; i++)
            {
                List<int> list = new List<int>();
                //随机获取奇数
                var even = NumberGenerator.GetRandomEven();
                //随机数
                var res= NumberGenerator.GetRandomNumber();
                //30个数 添加随机偶数次
                for (int j = 0; j < 30; j++)
                {
                    //获取一个随机数
                    var n = NumberGenerator.GetRandomNumber(1,3);
                    //添加偶数次
                    for (int k = 0; k < 2*n; k++)
                    {
                        list.Add(n);
                    }
                }
                //某个数添加奇数次
                for (int p = 0; p < even; p++)
                {
                    list.Add(res);
                }

                var calRes = GetEvenNum(list.ToArray());
                if (calRes!=res)
                {
                    Console.WriteLine("错误数据");
                    Printer.Print(list.ToArray());

                    Printer.Print(new int[] { calRes, res });
                    success = false;
                    break;
                }
            }
            return success;
        }
       
        /// <summary>
        /// 获取出现奇数次的数
        /// </summary>
        /// <returns></returns>
        public int GetEvenNum(int[] arr)
        {
            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                res ^= arr[i];
            }
            return res;
        }
    }
}
