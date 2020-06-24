using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class Banana<T> : Product<T>
    {
        public Banana(string name, T volume, T calories) : base(name, volume, calories)
        {
        }
    }
}
