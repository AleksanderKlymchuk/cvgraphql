using System.Collections.Generic;
using Model;
using System.Linq;

namespace Repository
{
    public class PersonRepository :Repository<Person>, IPersonRepository
    {
        public PersonRepository(CVContext context) : base(context)
        {
           
        }

        public IEnumerable<Person> GetAll(string orderby)
        {
            orderby = orderby ?? "firstname";
            return _context.Set<Person>().SqlQuery($"select * from Person order by {orderby} asc").ToList();
        }
    }
}
