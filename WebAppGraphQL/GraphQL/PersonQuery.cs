using GraphQL.Types;
using Model;
using Model.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PersonQuery : ObjectGraphType<object>
    {

        public PersonQuery(IUnitOfWork unitOfWork)
        {
           
            Field<PersonType>(
                "person",
                arguments: new QueryArguments(
                     new QueryArgument<StringGraphType>() { Name = "firstName" },
                     new QueryArgument<StringGraphType>() { Name = "lastName" }

                    ),

                     resolve: context =>
                     {
                         var firstName = context.GetArgument<string>("firstName");
                         var lastName = context.GetArgument<string>("lastName");

                         var spec = new PersonSpecification(firstName, lastName);
                        return unitOfWork.Persons.Find(spec.Criteria).FirstOrDefault();
                       
                     }
                );
          
        }
    }
}
