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

        public void Set<T>(T input, ref Property<T> output)
        {
            if (input != null)
            {
                output = input;
            }
            else
            {
                output = null;
            }
        }


    }
    public class CourseProperties
    {
        public Property<int> Id;

    }
}
