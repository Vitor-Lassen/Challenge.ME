using Domain.Contracts.Repositories;
using Infra.Provider;
using System.Linq.Expressions;

namespace Infra.Repositories
{
    public class BaseRepository<T,Tkey> : IDisposable, IBaseRepository<T, Tkey> where T : class
    {
        protected readonly ContextDb _context;
        private bool disposed = false;
        public BaseRepository(ContextDb context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(Tkey id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Update (T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
        protected IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
