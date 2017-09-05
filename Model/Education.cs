using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Education
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string InstitutionName{ get; set; }
        public string Specialization { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
