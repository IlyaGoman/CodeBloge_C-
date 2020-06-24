using System;
using System.Collections.Generic;

namespace EntityApp
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public string Type { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}