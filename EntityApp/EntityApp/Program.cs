using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var group = new Group()
                {
                    Name = "Rammstain",
                    Year = 1994
                };

                var group2 = new Group()
                {
                    Name = "Linkin Park"
                };

                context.GroupSet.Add(group);
                context.GroupSet.Add(group2);
                context.SaveChanges();

                var songs = new List<Song>()
                {
                    new Song() {Name="Mutter", GroupId=group.Id },
                    new Song() {Name="FuckOff", GroupId=group2.Id },
                    new Song() {Name="America", GroupId=group.Id },
                };

                context.SongSet.AddRange(songs);
                context.SaveChanges();

            }
        }
    }
}
