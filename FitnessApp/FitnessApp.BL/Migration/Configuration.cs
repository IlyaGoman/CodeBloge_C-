using System.Data.Entity.Migrations;

namespace FitnessApp.BL.Migration
{
    internal sealed class Configuration : DbMigrationsConfiguration<FitnessApp.BL.Controllers.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "FitnessApp.BL.Controllers.FitnessContext";
        }


        protected override void Seed(FitnessApp.BL.Controllers.FitnessContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
