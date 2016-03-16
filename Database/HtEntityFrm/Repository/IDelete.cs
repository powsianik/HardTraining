namespace EntityFrameworkDomain.Repository
{
    public interface IDelete<T> where T : class
    {
        void Delete(T entity);
    }
}