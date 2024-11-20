namespace PasswordHashing.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IQueryable<T> GetAll();
    }
}
