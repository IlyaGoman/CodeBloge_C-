using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class Product<T>
    {
        public string Name { get; set; }
        public T Volume { get; set; }
        public T Calories { get; set; }
        public Product(string name, T volume, T calories)
        {
            Name = name;
            Volume = volume;
            Calories = calories;
        }

        public override string ToString()
        {
            return $"Product: {Name}, volume: {Volume}, Calories: {Calories}";
        }
    }
}
