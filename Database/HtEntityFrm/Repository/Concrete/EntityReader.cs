using System;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkDomain.Repository.Concrete
{
    public class EntityReader<T> : IReadAll<T> where T : class
    {
        private readonly DbContext dbContext;

        public EntityReader(DbContext context)
        {
            this.dbContext = context;
        }

        public IQueryable<T> ReadAll()
        {
            return this.dbContext.Set<T>();
        }
    }
}