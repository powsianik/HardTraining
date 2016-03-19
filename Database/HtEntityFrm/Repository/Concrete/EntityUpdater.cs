using System;
using System.Data.Entity;

namespace EntityFrameworkDomain.Repository.Concrete
{
    public class EntityUpdater<T> : IUpdate<T>, IDisposable where T : class
    {
        private readonly DbContext dbContext;

        public EntityUpdater(DbContext context)
        {
            this.dbContext = context;
        } 

        public void Update(T entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}