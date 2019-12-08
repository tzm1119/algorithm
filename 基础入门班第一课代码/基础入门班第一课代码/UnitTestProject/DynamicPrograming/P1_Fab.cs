using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.DynamicPrograming
{
    /// <summary>
    /// 斐波那契数列相关问题
    /// </summary>
    public class P1_Fab
    {

        #region 斐波那契数列
        public int f1(int n)
        {
            if (n < 1)
            {
                return 0;
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }
            return f1(n - 1) + f1(n - 2);
        }

        public int f2(int n)
        {
            if (n < 1)
            {
                return 0;
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }
            int res = 1;
            int pre = 1;
            int tmp = 0;
            for (int i = 3; i <= n; i++)
            {
                tmp = res;
                res = res + pre;
                pre = tmp;
            }
            return res;
        }
        #endregion

        #region 爬楼梯问题
        public int PaLouTi(int n)
        {
            if (n<1)
            {
                return 0;
            }
            if (n==1)
            {
                return 1;
            }
            if (n==2)
            {
                return 2;
            }
            return PaLouTi(n - 1) + PaLouTi(n - 2);
        }

        public int PaLouTi2(int n)
        {
            if (n<1)
            {
                return 0;
            }
            if (n==1)
            {
                return 1;
            }
            if (n==2)
            {
                return 2;
            }
            int res = 2;
            int pre = 1;
            int tmp = 0;
            for (int i = 3; i <= n; i++)
            {
                tmp = res;
                res = res + pre;
                pre = tmp;
            }
            return res;
        }


        #endregion

        #region 生牛问题
        public int NiuBirth(int n)
        {
            if (n<1)
            {
                return 0;
            }
            if (n<=3)
            {
                return n;
            }
            return NiuBirth(n - 1) + NiuBirth(n - 3);
        }

        public int NiuBirth2(int n)
        {
            if (n < 1)
            {
                return 0;
            }
            if (n <= 3)
            {
                return n;
            }
            int res = 3;
            int pre = 2;
            int prePre = 1;
            int tmp = 0;
            int tmp2 = 0;
            for (int i = 4; i <=n; i++)
            {
                tmp = res;
                tmp2 = pre;
                res = res + prePre;
                prePre = tmp2;
                pre = res;
            }
            return res;
            
        }


        #endregion

    }
}
