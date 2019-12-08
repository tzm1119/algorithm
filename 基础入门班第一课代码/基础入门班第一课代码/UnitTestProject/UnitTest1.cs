using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Cache;
using UnitTestProject.QueueStack;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LRUCache_Test()
        {
           
        }

        [TestMethod]
        public void DogCatQueue_Test()
        {
            new P4_DogCatQueue().Run();
        }
    }
}
