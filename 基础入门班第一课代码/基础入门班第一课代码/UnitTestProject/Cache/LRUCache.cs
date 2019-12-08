using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject.Common;

namespace UnitTestProject.Cache
{
    public class LRUCache : Cache<string, int>, IExecTest
    {
        public LRUCache(int size)
        {
            this.size = size;
        }
        private int size;

        private Dictionary<string, Node> cacheDic = new Dictionary<string, Node>();
        public int Get(string key)
        {
            if (!cacheDic.ContainsKey(key))
            {
                throw new Exception("key is not exist");
            }
            ChangeHistoryOrder(key);
            return cacheDic[key].Value;
        }

        public void Set(string key, int value)
        {
            var n = new Node
            {
                Key = key,
                Value = value
            };
            //更新操作
            if (cacheDic.ContainsKey(key))
            {
                cacheDic[key].Value = value;
                ChangeHistoryOrder(key);
            }
            //新增操作
            else
            {
                if (cacheDic.Count < size)
                {

                    //加入缓存字典
                    cacheDic[key] = n;
                    //加入历史
                    AddNodeToHistory(n);
                }
                else
                {
                    //加入缓存字典
                    cacheDic[key] = n;
                    //加入历史
                    AddNodeToHistory(n);
                    //移除最旧的节点
                    RemoveOldestNode();
                }
            }
           
        }
        /// <summary>
        /// 由于缓存数量过多，删除最旧的节点
        /// </summary>
        private void RemoveOldestNode()
        {
            historyTail.Pre.Next = null;
            historyTail = historyTail.Pre;
        }
        /// <summary>
        /// 在新增操作时，需要把新增的节点加入到历史队列中
        /// </summary>
        /// <param name="node"></param>
        private void AddNodeToHistory(Node node)
        {
            if (historyHead==null)
            {
                historyHead = node;

                historyTail = node;
            }
            else
            {
                //新增的node指向head,并更新head
                node.Next = historyHead;
                historyHead.Pre = node;
                historyHead = node;
            }
        }
        /// <summary>
        /// 由于get或者set新节点，此时需要改变最旧的节点
        /// </summary>
        private void ChangeHistoryOrder(string key)
        {
           var node= cacheDic[key];
            if (node!=historyHead)
            {
                node.Pre.Next = node.Next;
                if (node!=historyTail)
                {
                    node.Next.Pre = node.Pre;
                }
                else
                {
                    historyTail = historyTail.Pre;
                }
                //把node加入到历史的头部
                AddNodeToHistory(node);
            }
        }

        public void Run()
        {
            LRUCache lRUCache = new LRUCache(3);
            //添加5个key
            for (int i = 0; i < 5; i++)
            {
                lRUCache.Set($"{i}", i);
            }
            //头是4
            Assert.IsTrue(lRUCache.historyHead.Value == 4);
            //尾是2
            Assert.IsTrue(lRUCache.historyTail.Value == 2);
            lRUCache.Get("2");
            //头是4
            Assert.IsTrue(lRUCache.historyHead.Value == 2);
            //尾是2
            Assert.IsTrue(lRUCache.historyTail.Value == 3);
            lRUCache.Set($"6", 6);
            //头是6
            Assert.IsTrue(lRUCache.historyHead.Value == 6);
            //尾是4
            Assert.IsTrue(lRUCache.historyTail.Value == 4);
            //重复get头
            lRUCache.Get($"6");
            //头是6
            Assert.IsTrue(lRUCache.historyHead.Value == 6);
            //尾是4
            Assert.IsTrue(lRUCache.historyTail.Value == 4);
        }

        public Node historyHead;
        public Node historyTail;

       public  class Node
        {
            public Node Pre { get; set; }
            public Node Next { get; set; }

            public string Key { get; set; }
            public int Value { get; set; }
        }
    }

    
}
