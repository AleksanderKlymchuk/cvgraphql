using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IRepository<T> where T: class
    {
        T Get(int Id);
        IEnumerable<T> Find(Expression<Func<T, bool>>predicate);
        void Add(T obj);
        void AddRange(IEnumerable<T>objects);
        void Remove(T obj);
        void RemoveRange(IEnumerable<T>objects);    
    }
}
