using System.Linq;

namespace EntityFrameworkDomain.Repository
{
    public interface IReadAll<T> where T:class
    {
        IQueryable<T> ReadAll();
    }
}