using System;

namespace LinqApp
{
    class Product
    {
        public string Name { get; set; }

        public int Energy { get; set; }

        public override string ToString()
        {
            return $"Product name: {Name}, Calories: {Energy}";
        }
    }
}
