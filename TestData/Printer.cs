using System;
using System.Collections.Generic;
using System.Text;

namespace TestData
{
    public static class Printer
    {
        public static void Print(this int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
