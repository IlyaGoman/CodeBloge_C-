using System;
using System.Linq;

namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var photo = new Photo("hello.png")
            {
                Path = @"C:\",
                Size = 3.5
            };

            var type = typeof(Photo);

            Console.WriteLine(type);
            Console.WriteLine();

            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                var attributes = item.GetCustomAttributes(false);

                if (attributes.Any(x => x.GetType() == typeof(GeoAttribute)))
                {

                    Console.WriteLine(item.PropertyType + " " + item.Name);

                    //foreach (var attr in attributes)
                    //{
                    //    Console.WriteLine(attr);
                    //}
                }
            }
            
            Console.ReadLine();
        }
    }
}
