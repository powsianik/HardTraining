using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EntityFrameworkDomain.Context.Interfaces;
using HardTrainingPoco.Models.UserDataModule;
using HardTrainingPoco.POCO.Logger;

namespace EntityFrameworkDomain.Context.Concrete
{
    public class HardTrainingMainContext : DbContext, ILoggerContext
    {
        public HardTrainingMainContext()
            : base("HardTrainingConnection")
        {
        }
        
        /*Tables:*/
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserBasicData> UserDatas { get; set; }

        public static HardTrainingMainContext Create()
        {
            return new HardTrainingMainContext();   
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Tutaj przy rozbudowie bazy należy rozważyć wyłączenie konwencji CascadeDelete, i ewentualne jej włączanie za pomocą FluentAPI*/
        }
    }
}
