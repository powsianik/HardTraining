using System;
using System.Data.Entity;

namespace EntityFrameworkDomain.Repository.Concrete
{
    public class EntityCreator<T> : ICreate<T>, IDisposable where T: class
    {
        private readonly DbContext dbContext;

        public EntityCreator(DbContext context)
        {
            this.dbContext = context;
        } 

        public void Create(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }
    }
}