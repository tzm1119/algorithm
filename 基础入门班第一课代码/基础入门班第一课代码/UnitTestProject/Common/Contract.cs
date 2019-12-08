using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Common
{
    public interface Cache<TKey, TValue>
    {
        void Set(TKey key, TValue value);
        TValue Get(TKey key);
    }

    public interface IExecTest
    {
        void Run();
    }
}
