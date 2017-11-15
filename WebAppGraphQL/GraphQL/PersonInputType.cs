using GraphQL.Language.AST;
using GraphQL.Resolvers;
using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PersonInputType : InputObjectGraphType
    {
        public PersonInputType()
        {
            Name = "PersonInput";
            Field<StringGraphType>("LastName");
            Field<StringGraphType>("FirstName");
            Field<IntGraphType>("Age");
            Field<ListGraphType<IntGraphType>>("Courses");
        }


    }
    
    
}


