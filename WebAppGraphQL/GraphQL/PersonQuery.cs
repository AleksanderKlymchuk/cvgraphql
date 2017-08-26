using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PersonQuery : ObjectGraphType<object>
    {

        public PersonQuery(IPersonRepository personRepository)
        {
            Field<PersonType>("person",
                arguments: new QueryArguments(
                     new QueryArgument<StringGraphType>() { Name = "firstName" },
                     new QueryArgument<StringGraphType>() { Name = "lastName" }
                     
                    ),

                     resolve: context =>
                     {
                         var firstName = context.GetArgument<string>("firstName");
                         var lastName = context.GetArgument<string>("lastName");
                         return personRepository.GetPerson(firstName,lastName);
                     }
                );
          
        }
    }
}
