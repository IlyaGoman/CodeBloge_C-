using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    public static class Helper
    {
        public static bool TryParse<T>(this String input, out T parsedValue)
        {
            parsedValue = default(T);
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                parsedValue = (T)converter.ConvertFromString(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
