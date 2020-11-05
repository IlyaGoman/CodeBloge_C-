using System.Collections;

namespace QueueApp
{
    public class LinkedQueue<T>:IEnumerable
    {
        public Item<T> head;
        public Item<T> tail;


        public int Count { get; private set; }

        public LinkedQueue(T data)
        {
            SetHeadItem(data);
        }

        private void SetHeadItem(T data)
        {
            var item = new Item<T>(data);
            head = item;
            tail = item;
            Count = 1;
        }

        public void Enqueue(T data)
        {
            if(Count == 0)
            {
                SetHeadItem(data);
                return;
            }

            var item = new Item<T>(data);
            tail.Next = item;
            tail = item;
            Count++;
        }

        public T Dequeue()
        {
            var result = head;
            head = head.Next;
            return result.Data;
        }

        public T Peek()
        {
            return head.Data;
        }

        public IEnumerator GetEnumerator()
        {
            var current = head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
