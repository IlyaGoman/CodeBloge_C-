using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Model
{
    class Item<T>
    {
        private T data = default(T);
        private Item<T> next = null;

        public T Data
        {
            get => data;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(data));
                data = value;
            }
        }

        public Item<T> Next
        {
            get; set;
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
