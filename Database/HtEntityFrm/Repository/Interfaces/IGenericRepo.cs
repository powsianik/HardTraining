using System.Linq;

namespace EntityFrameworkDomain.Repository.Interfaces
{
    public interface IGenericRepo<TEntity> where TEntity: class 
    {
        IQueryable<TEntity> GetAll();
        void Add(TEntity profile);
        void Delete(TEntity profile);
        void Update(TEntity profile);
    }
}