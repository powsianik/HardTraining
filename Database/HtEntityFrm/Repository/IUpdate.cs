namespace EntityFrameworkDomain.Repository
{
    public interface IUpdate<T> where T : class
    {
        void Update(T entity);
    }
}