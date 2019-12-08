using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace TestData
{
    public class Watcher
    {
        public static long PrintTime(string desc,Action action,bool printRes)
        {
            Stopwatch stopwatch=null;
            try
            {
                 stopwatch = Stopwatch.StartNew();
                 action();
                return stopwatch.ElapsedMilliseconds;
            }
            finally
            {
                if (printRes)
                {
                    Console.WriteLine($"{desc } 执行时间为 {stopwatch.ElapsedMilliseconds} ms");
                }
              
            }
           
        }
    }
}
