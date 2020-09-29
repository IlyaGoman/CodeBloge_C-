using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace QueueApp
{
    public class EasyQueue<T>:IEnumerable
    {
        private List<T> items = new List<T>();

        private T Head => items.Last();
        private T Tail => items.First();

        public int Count => items.Count;

        public EasyQueue()
        {

        }

        public EasyQueue(T data)
        {
            items.Add(data);
        }

        public void Enqueue(T data)
        {
            items.Insert(0, data);
        }

        public T Dequeue()
        {
            var result = Head;
            
            if(Count>0)
                items.RemoveAt(Count - 1);

            return result;
        }

        public T Peek()
        {
            return Head;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            var reverseItems = items;
            reverseItems.Reverse();

            foreach (var item in reverseItems)
            {
                yield return item;
            }
        }
    }
}
