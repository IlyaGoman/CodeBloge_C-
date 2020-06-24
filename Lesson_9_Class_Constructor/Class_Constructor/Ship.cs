using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Constructor
{
    class Ship
    {
        private string _name;

        public string GetName()
        {
            return _name;
        }

        public void SetName(string value)
        {
            this._name = value;
        }

        public override string ToString()
        {
            return $"Ship_name = {_name}";
        }
    }
}
