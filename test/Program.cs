using System;
using System.Collections.Generic;
using System.Linq;
using test.Sort;
using TestData;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 排序
            //InsertSort insertSort = new InsertSort();
            //PopSort popSort = new PopSort();
            //SelectSort selectSort = new SelectSort();

            //for (int i = 0; i < 500; i++)
            //{
            //    PrintSplit();
            //    var arr = ArrayGenerator.GetTestArray(30, -500, 1000);
            //    var a1 = insertSort.Sort((int[])arr.Clone());
            //    var a2 = popSort.Sort((int[])arr.Clone());
            //    var a3 = selectSort.Sort((int[])arr.Clone());
            //    bool allEqual = ArrayGenerator.ArrayEqual(a1, a2) && ArrayGenerator.ArrayEqual(a1, a3);
            //    if (allEqual)
            //    {
            //        Console.WriteLine($"{i} success");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{i} fail");
            //        a1.Print();
            //        a2.Print();
            //        a3.Print();

            //    }
            //    PrintSplit();
            //}
            #endregion

            //N和M的数量级
            //TestHelper.Run(new Jusephuskill());

            TestHelper.Run(new EvenTimesOddTimes());
            

        }
       public static void PrintSplit()
        {
            Console.WriteLine("********************************************");
        }

    }

}
