using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    public interface ICanTest
    {
        /// <summary>
        /// 测试算法是否正确
        /// </summary>
        /// <returns></returns>
        bool TestSuccess();
        /// <summary>
        /// 测试算法的时间复杂度
        /// </summary>
        void TestBigO();
    }

    public class TestHelper
    {
        public static void Run(ICanTest canTest)
        {
            if (canTest.TestSuccess())
            {
                Console.WriteLine("正确性 测试通过");
                canTest.TestBigO();
            }
            else
            {
                Console.WriteLine("未通过正确性测试...!");
            }
        }
    }
}
