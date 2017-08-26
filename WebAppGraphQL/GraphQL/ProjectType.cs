using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class ProjectType: ObjectGraphType<Project>
    {
        public ProjectType()
        {
            Field(x => x.Id).Description("Project Id");
            Field(x => x.Name).Description("Project Name");
        }
    }
}
