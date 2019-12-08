using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.QueueStack
{
    public class P5_StackOrder
    {
        public void Sort(Stack<int> sk)
        {
            Stack<int> help = new Stack<int>();
            while (sk.Count != 0)
            {
                var cur = sk.Pop();
                while (help.Count!=0&&help.Peek()<cur)
                {
                    sk.Push(help.Pop());
                }
                help.Push(cur);
            }
            while (help.Count!=0)
            {
                sk.Push(help.Pop());
            }
        }
    }
}
