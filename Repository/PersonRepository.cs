using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PersonRepository : IPersonRepository
    {
       
        public Person GetPerson(string firstName, string LastName)
        {
            return PersonMock.Persons().Where(x => x.FirstName.ToLower() == firstName.ToLower() && x.LastName.ToLower() == LastName.ToLower()).FirstOrDefault();
        }
       
    }
}
