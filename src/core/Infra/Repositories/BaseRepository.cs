using Domain.Contracts.Repositories;
using Infra.Provider;

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
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public virtual T GetById(Tkey id)
        {
            return _context.Set<T>().Find(id);
        }
        public virtual void Update (T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
        protected virtual IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
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
