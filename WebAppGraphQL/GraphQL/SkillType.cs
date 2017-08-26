using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class SkillType: ObjectGraphType<Skill>
    {
        public SkillType()
        {
            Field(x => x.Id).Description("Skill Id");
            Field(x => x.Name).Description("Skill Name");
        }
    }
}
