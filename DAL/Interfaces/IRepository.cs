namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {

        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        IQueryable<T> GetAll();
        T Get(int id);
        void SaveAll(IEnumerable<T> updatalist);

    }
}