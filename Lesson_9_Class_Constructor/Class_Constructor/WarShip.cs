using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Constructor
{
    class WarShip:Ship
    {
        private int _valueGun;
        public int ValueGun 
        {
            get { return _valueGun; }
            set
            {
                //if (int.TryParse(value, out int result))
                this._valueGun = value;
            }
        }
    }
}
