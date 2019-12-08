using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.QueueStack
{
    public class P2_TwoStackQueue
    {
        Stack<int> stackPush = new Stack<int>();
        Stack<int> stackPop = new Stack<int>();
        string queueEmptyException = "Queue is empty";
        public void Add(int num)
        {
            stackPush.Push(num);
            pushToPop();
        }

        public int Poll()
        {
            if (stackPop.Count==0 && stackPush.Count==0)
            {
                throw new Exception(queueEmptyException);
            }
            pushToPop();
            return stackPop.Pop();
            
        }

        void pushToPop()
        {
            if (stackPop.Count==0)
            {
                while (stackPush.Count>0)
                {
                    stackPop.Push(stackPush.Pop());
                }
            }
        }
    }
}
