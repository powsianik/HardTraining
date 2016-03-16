using System;
using System.Data.Entity;

namespace EntityFrameworkDomain.Repository.Concrete
{
    public class EntityDeleter<T> : IDelete<T>, IDisposable where T : class
    {
        private readonly DbContext dbContext;

        public EntityDeleter(DbContext context)
        {
            this.dbContext = context;
        }

        public void Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }
    }
}