using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonSkill
    {
        public int ID{ get; set; }
        public int PersonID { get; set; }
        public int SkillID { get; set; }
        public string Level { get; set; }
        public Person Person { get; set; }
        public Skill Skill { get; set; }
    }
}
