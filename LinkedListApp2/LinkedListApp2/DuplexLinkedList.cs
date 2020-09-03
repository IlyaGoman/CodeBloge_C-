using System;
using System.Collections;

namespace LinkedListApp2
{
    public class DuplexLinkedList<T>: IEnumerable
    {
        public DuplexItem<T> Head { get; set; }

        public DuplexItem<T> Tail { get; set; }

        public int Count { get; set; }

        public DuplexLinkedList()
        {
            
        }

        public DuplexLinkedList(T data)
        {
            var item = new DuplexItem<T>(data);
            Head = item;
            Tail = item;
            Count++;
        }

        public void Add(T data)
        {
            var item = new DuplexItem<T>(data);
            if (Head == null)
            {
                Head = item;
                Tail = item;
            }
            else
            {
                Tail.Next = item;
                item.Previous = Tail;
                Tail = item;
            }
            Count++;
        }

        public void Delete(T data)
        {
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if(current.Data.Equals(data))
                    {
                        if (current.Previous == null)
                        {
                            current.Next.Previous = null;
                            Head = current.Next;
                        }
                        else if (current.Next == null)
                        {
                            current.Previous.Next = null;
                            Tail = current.Previous;
                        }
                        else
                        {
                            current.Previous.Next = current.Next;
                            current.Next.Previous = current.Previous;
                        }
                        Count--;
                        return;
                    }
                    current = current.Next;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
    }
}
