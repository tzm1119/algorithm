using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    /// <summary>
    /// 吃草问题
    /// 
    /// 牛羊吃草，每次只能吃 4 的 次方个草，即1,4,16,64...，谁吃最后一口，谁赢
    /// 给定草的个数n,求先吃赢，还是后吃赢
    /// </summary>
    public class ChiCao
    {
        public static string hou = "后手";
        public static string xian = "先手";
        public static string Winner(int n)
        {
            // 0   1   2   3   4
            // 后 先  后  先  先

            if (n < 5)
            {
                if (n == 0 || n == 2)
                {

                    return hou;
                }
                else
                {
                    return xian;
                }
            }

            if (Winner(n - 1) == xian)
            {
                return hou;
            }
            else
            {
                return xian;
            }

        }
    }
}
