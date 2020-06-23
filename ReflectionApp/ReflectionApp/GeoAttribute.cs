using System;

namespace ReflectionApp
{
    class GeoAttribute: Attribute
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GeoAttribute()
        {

        }

        public GeoAttribute(int x, int y)
        {

        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}
