using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository
{
    public class PersonRepository :Repository<Person>, IPersonRepository
    {
        public PersonRepository() : base(new CVContext())
        {
        }
        
        private CVContext CVContext
        {
            get { return _context as CVContext; }
        }
    }
}
