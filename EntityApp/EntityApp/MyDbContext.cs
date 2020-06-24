using System;
using System.Data.Entity;

namespace EntityApp
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {

        }

        public DbSet<Group> GroupSet { get; set; }
        public DbSet<Song> SongSet { get; set; }
    }
}
