using FitnessApp.BL.Model;
using System;
using System.Data.Entity;

namespace FitnessApp.BL.Controllers
{
    public class FitnessContext : DbContext
    {
        public FitnessContext(): base("DbConnectionString")
        {
                
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eating { get; set; }
        public DbSet<Exercise> Exercisies { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
