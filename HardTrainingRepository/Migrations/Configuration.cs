using HardTrainingRepository.Models;
using HardTrainingRepository.Models.Context.Concret;
using HardTrainingRepository.Models.Logger;

namespace HardTrainingRepository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LoggerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LoggerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            this.SeedProfiles(context);
        }

        private void SeedProfiles(LoggerContext context)
        {
            for (int i = 0; i < 5; ++i)
            {
                Profile profile = new Profile() { CreationDate = DateTime.Now, Name = "Pshepo", Password = "rbk55m" };

                context.Set<Profile>().AddOrUpdate(profile);
            }
            
            context.SaveChanges();
        }
    }
}
