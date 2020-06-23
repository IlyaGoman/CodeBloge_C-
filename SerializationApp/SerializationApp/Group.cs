using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationApp
{
    [Serializable]
    public class Group
    {
        [NonSerialized]
        private readonly Random rnd = new Random(DateTime.Now.Millisecond);
        public int Number { get; set; }

        public string Name { get; set; }

        private int PrivateProperty { get; set; }

        public Group()
        {
            Number = rnd.Next(1, 10);
            Name = "Group " + Number;
            PrivateProperty = rnd.Next();
        }

        public Group(int number, string name)
        {
            Number = number;
            Name = name;
            PrivateProperty = rnd.Next();
        }

        public override string ToString()
        {
            return Name + " || " + PrivateProperty;
        }
    }
}
