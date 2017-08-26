using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class EducationType: ObjectGraphType<Education>
    {
        public EducationType()
        {
            Field(x => x.Id).Description("Education Id");
            Field(x => x.Title).Description("Education Name");
            Field(x => x.Specialization).Description("Education Specialization");
            Field(x => x.InstitutionName).Description("Education InstitutionName");
            Field(x => x.Start).Description("Education Start");
            Field(x => x.End).Description("Education End");
        }
    }
}
