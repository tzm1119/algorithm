using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.QueueStack
{
    public class P1_GetMin
    {
        Stack<int> stackData = new Stack<int>();
        Stack<int> stackMin = new Stack<int>();
        string emptyException = "stack is empty";

        public void Push(int num)
        {
            if (this.stackMin.Count == 0)
            {
                this.stackMin.Push(num);
            }
            else if (num < this.GetMin())
            {
                this.stackMin.Push(num);
            }
            this.stackData.Push(num);
        }

        public int Pop()
        {
            if (stackData.Count == 0)
            {
                throw new Exception(emptyException);
            }

            var res = this.stackData.Pop();
            if (res == GetMin())
            {
                stackMin.Pop();
            }
            return res;

        }

        public int GetMin()
        {
            if (this.stackMin.Count == 0)
            {
                throw new Exception(emptyException);
            }
            return this.stackMin.Peek();
        }
    }

    public class P1_GetMin2
    {
        Stack<int> stackData = new Stack<int>();
        Stack<int> stackMin = new Stack<int>();
        string emptyException = "stack is empty";

        public void Push(int num)
        {
            if (this.stackMin.Count == 0)
            {
                this.stackMin.Push(num);
            }
            else if (num < this.GetMin())
            {
                this.stackMin.Push(num);
            }
            else
            {
                //添加重复的最小值
                int newMin = GetMin();
                stackMin.Push(newMin);
            }
            this.stackData.Push(num);
        }

        public int Pop()
        {
            if (stackData.Count == 0)
            {
                throw new Exception(emptyException);
            }

            var res = this.stackData.Pop();
            this.stackMin.Pop();
            return res;

        }

        public int GetMin()
        {
            if (this.stackMin.Count == 0)
            {
                throw new Exception(emptyException);
            }
            return this.stackMin.Peek();
        }
    }
}
