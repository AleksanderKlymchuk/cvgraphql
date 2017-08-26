using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class CompanyType: ObjectGraphType<Company>
    {
        public CompanyType()
        {
            Name= "positions";
            Field(x => x.Id).Description("Company Id");
            Field(x => x.Name).Description("Company Name");
            Field<ListGraphType<PositionType>>("Positions");
        }
    }
}
