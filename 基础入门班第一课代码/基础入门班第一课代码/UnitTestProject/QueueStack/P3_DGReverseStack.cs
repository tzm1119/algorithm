using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.QueueStack
{
    /// <summary>
    /// 只用递归，逆序一个栈
    /// </summary>
    public  class P3_DGReverseStack
    {
        int getAndRemoveLast(Stack<int> sk)
        {
            int res = sk.Pop();
            if (sk.Count==0)
            {
                return res;
            }
            else
            {
                int last = getAndRemoveLast(sk);
                sk.Push(res);
                return last;
            }
        }

        public void Reverse(Stack<int> sk)
        {
            if (sk.Count==0)
            {
                return;
            }
            int i = getAndRemoveLast(sk);
            Reverse(sk);
            sk.Push(i);
        }
    }
}
