using System.Security.Policy;

namespace QueueApp
{
    public class Item<T>
    {
        public T Data { get; private set; }

        public Item<T> Next { get; set; }

        public Item()
        {

        }

        public Item(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
