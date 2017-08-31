using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersonRepository:IRepository<Person>
    {
       /// Person GetPerson(string firstName,string LastName);
       
    }
}
