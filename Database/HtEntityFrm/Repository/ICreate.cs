namespace EntityFrameworkDomain.Repository
{
    public interface ICreate<T> where T:class
    {
        void Create(T entity);
    }
}