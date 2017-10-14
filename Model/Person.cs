using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Person")]
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<PersonSkill> PersonSkills { get; set; }
        //public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

    }
    public class PersonProperties
    {
        public Property<string> FirstName;
        public Property<string> LastName;
        public Property<int?> Age;
        public Property<IEnumerable<CourseProperties>> Courses; 

        public Property<T> Set<T>(T input)
        {
            Property<T> prop=null;
            if (input != null)
            {
                prop = input;
                return prop.Value;
            }
            return prop;
        }

    }
    public class CourseProperties
    {
        public Property<int> Id;

    }
}
