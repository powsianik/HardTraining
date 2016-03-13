using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EntityFrameworkDomain.Models.Logger;

namespace EntityFrameworkDomain.Models.Context.Concrete
{
    public class LoggerContext : DbContext, ILoggerContext
    {
        public LoggerContext()
            : base("HardTrainingConnection")
        {
        }
        
        /*Tables:*/
        public DbSet<Profile> Profiles { get; set; }

        public static LoggerContext Create()
        {
            return new LoggerContext();   
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Tutaj przy rozbudowie bazy należy rozważyć wyłączenie konwencji CascadeDelete, i ewentualne jej włączanie za pomocą FluentAPI*/
        }
    }
}
