using AutoMapper;

namespace BLL.Interfaces
{
    public interface IService<T> where T : IDTO
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T Get(int id);
        void SaveAll(IEnumerable<T> updatalist);
    }
}
