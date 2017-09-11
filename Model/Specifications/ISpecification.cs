using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Specifications
{
    public interface ISpecification<T> where T:class
    {
        Expression<Func<T,bool>> Criteria { get; }
    }
}
