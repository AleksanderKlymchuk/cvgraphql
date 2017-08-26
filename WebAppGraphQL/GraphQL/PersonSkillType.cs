using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PersonSkillType: ObjectGraphType<PersonSkill>
    {
        public PersonSkillType()
        {
          
            Field(x=>x.Level).Description("Skill Level");
            Field<SkillType>("Skill", "person skill");
        }
    }

}
