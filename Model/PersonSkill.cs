using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonSkill
    {
        public int PersonId { get; set; }
        public int SkillId { get; set; }
        public string Level { get; set; }
        public Person Person { get; set; }
        public Skill Skill { get; set; }
    }
}
