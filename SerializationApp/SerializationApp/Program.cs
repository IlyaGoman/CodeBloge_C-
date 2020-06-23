using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace SerializationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = new List<Group>();
            var students = new List<Student>();

            for (int i = 1; i <= 10; i++)
            {
                groups.Add(new Group(i, "Group " + i));
            }

            for (int i = 0; i < 300; i++)
            {
                var student = new Student(Guid.NewGuid().ToString().Substring(0, 5), i % 3)
                {
                    Group = groups[i % 9]
                };

                students.Add(student);
            }

            #region Bin
            //var binFormatter = new BinaryFormatter();

            //using (var file= new FileStream("groups.bin", FileMode.OpenOrCreate))
            //{
            //    binFormatter.Serialize(file, groups);
            //}

            //using (var file = new FileStream("groups.bin", FileMode.OpenOrCreate))
            //{
            //    var newGroups = binFormatter.Deserialize(file) as List<Group>;

            //    if(newGroups!=null)
            //    {
            //        foreach (var group in newGroups)
            //        {
            //            Console.WriteLine(group);
            //        }
            //    }
            //}
            #endregion

            #region SOAP
            //var soap = new SoapFormatter();

            //using (var file = new FileStream("groups.soap", FileMode.OpenOrCreate))
            //{

            //    soap.Serialize(file, groups.ToArray());
            //}

            //using (var file = new FileStream("groups.soap", FileMode.OpenOrCreate))
            //{
            //    var newGroups = soap.Deserialize(file) as Group[];

            //    if (newGroups != null)
            //    {
            //        foreach (var group in newGroups)
            //        {
            //            Console.WriteLine(group);
            //        }
            //    }
            //}
            #endregion

            var soap = new SoapFormatter();

            using (var file = new FileStream("groups.soap", FileMode.OpenOrCreate))
            {

                soap.Serialize(file, groups.ToArray());
            }

            using (var file = new FileStream("groups.soap", FileMode.OpenOrCreate))
            {
                var newGroups = soap.Deserialize(file) as Group[];

                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
