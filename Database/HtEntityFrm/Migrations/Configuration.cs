using HardTrainingPoco.POCO.PlanModule;

namespace EntityFrameworkDomain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkDomain.Context.Concrete.HardTrainingMainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFrameworkDomain.Context.Concrete.HardTrainingMainContext context)
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

            context.KindOfExercises.AddOrUpdate(new KindOfExercise() {Name = "Aerobowe", Description = "Jest to �wiczenie tlenowe, poprawiaj�ce wydolno��."});
            context.KindOfExercises.AddOrUpdate(new KindOfExercise() { Name = "Oporowe", Description = "Jest to �wiczenie si�owe, poprawiaj�ce wydolno��, si�� i konsystencje mi�ni."});
        }
    }
}
