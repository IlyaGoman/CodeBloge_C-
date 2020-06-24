using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class Apple<T> : Product<T>
    {
        public Apple(string name, T volume, T calories) : base(name, volume, calories)
        {

        }
    }
}
