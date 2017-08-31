using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
        }

        public void AddRange(IEnumerable<T> objects)
        {
            _context.Set<T>().AddRange(objects);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
          return  _context.Set<T>().Where(predicate);
        }

        public T Get(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
        }

        public void RemoveRange(IEnumerable<T> objects)
        {
            _context.Set<T>().RemoveRange(objects);
        }
    }
}
