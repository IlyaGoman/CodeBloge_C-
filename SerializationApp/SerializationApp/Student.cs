using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationApp
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Group Group { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Student name:{Name}, {Age}";
        }
    }
}
