using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PersonInputType: InputObjectGraphType
    {
        public PersonInputType()
        {
            Name = "PersonInput";
            Field<NonNullGraphType<StringGraphType>>("LastName");
            Field<NonNullGraphType<StringGraphType>>("FirstName");
        }
    }
}
