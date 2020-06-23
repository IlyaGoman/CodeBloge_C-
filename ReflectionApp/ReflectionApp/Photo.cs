using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionApp
{
    
    public class Photo
    {
        [Geo(10, 20)]
        public string Name { get; set; }

        public double Size { get; set; }

        [Geo(100, 200)]
        public string Path { get; set; }

        public Photo(string name)
        {
            Name = name;
        }
    }
}
