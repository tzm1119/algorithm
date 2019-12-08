using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.QueueStack
{
    public class P6_Hano
    {
        public int MainProcess(int num, string left, string mid, string right)
        {
            if (num < 1)
            {
                return 0;
            }
            return process(num, left, mid, right, left, right);
        }

        public int process(int num, string left, string mid, string right, string from, string to)
        {
            if (num == 1)
            {
                if (from == mid || to == mid)
                {
                    Console.WriteLine($"Move 1 from { from}  to {to}");
                    return 1;
                }
                else
                {
                    Console.WriteLine($"Move 1 from { from}  to {mid}");
                    Console.WriteLine($"Move 1 from { mid}  to {to}");
                    return 2;
                }
            }
            if (from==mid||to==mid)
            {
                string another = from == left || to == left ? right : left;
                int part1 = process(num - 1, left, mid, right, from, another);
                int part2 = 1;
                Console.WriteLine($"Move {num} from { from}  to {to}");
                int part3 = process(num - 1, left, mid, right, another, to);
                return part1 + part2 + part3;
            }
            else
            {
                int part1 = process(num - 1, left, mid, right, from, to);
                int part2 = 1;
                Console.WriteLine($"Move {num} from { from}  to {mid}");
                int part3 = process(num - 1, left, mid, right, to, from);
                int part4 = 1;
                Console.WriteLine($"Move {num} from { mid}  to {to}");
                int part5 = process(num - 1, left, mid, right, from, to);
                return part1 + part2 + part3 + part4 + part5;
            }
        }
    }
}
