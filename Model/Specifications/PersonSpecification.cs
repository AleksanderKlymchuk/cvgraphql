using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Specifications
{
    public class PersonSpecification : ISpecification<Person>
    {
        private string firstName { get; set; }
        private string lastName { get; set; }
        public PersonSpecification(string firstName,string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;

        }
        public Expression<Func<Person, bool>> Criteria
        {
            get
            {
                return s => s.FirstName.ToLower() == firstName.ToLower() && s.LastName.ToLower()==lastName.ToLower();
            }
        }
    }
}
