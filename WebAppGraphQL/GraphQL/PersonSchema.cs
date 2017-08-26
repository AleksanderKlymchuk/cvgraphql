using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PersonSchema : Schema
    {
        public PersonSchema(Func<Type, IGraphType> resolveType) : base(resolveType)
        {
            Query = (PersonQuery)resolveType(typeof(PersonQuery));
        }
    }
}
