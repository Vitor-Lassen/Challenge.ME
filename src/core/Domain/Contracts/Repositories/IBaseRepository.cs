using System.Linq.Expressions;

namespace Domain.Contracts.Repositories
{
    public interface IBaseRepository<T, Tkey> where T : class
    {
        T GetById(Tkey id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
