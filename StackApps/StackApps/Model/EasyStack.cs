using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StackApps.Model
{
    public class EasyStack<T>:IEnumerable
    {
        private List<T> items = new List<T>();

        private int Count => items.Count;

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (Count > 0)
            {
                var item = items.LastOrDefault();
                items.RemoveAt(Count-1);
                return items.LastOrDefault();
            }
            else
                throw new ArgumentNullException(nameof(items));
        }

        public T Peek()
        {
            if (Count > 0)
            {
                var item = items.LastOrDefault();
                return items.LastOrDefault();
            }
            else
                throw new NullReferenceException("Стек пуст");
        }

        public override string ToString()
        {
            return "Stack";
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
