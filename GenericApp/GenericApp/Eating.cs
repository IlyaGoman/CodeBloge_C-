using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class Eating<TT,T>
        where TT: Product<T>
    {
        public int Volume { get; set; }

        public void Add(TT product)
        {
            Volume += product.Volume * product.Calories;
        }
    }
}
