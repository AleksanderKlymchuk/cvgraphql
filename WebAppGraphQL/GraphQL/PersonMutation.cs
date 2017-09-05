using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PersonMutation:ObjectGraphType<object>
    {
        public PersonMutation(IUnitOfWork unitOfWork)
        {
            Field<PersonType>(
               "createPersonCV",
                    //arguments: new QueryArguments(
                    //     new QueryArgument<PersonType>() { Name = "person" }
                    //    ),
                    arguments: new QueryArguments(
                         new QueryArgument<NonNullGraphType<PersonInputType>>() { Name = "person" }
                        ),
                    resolve: context =>
                    {
                       
                        var person = context.GetArgument<Person>("person");
                        unitOfWork.Persons.Add(person);
                        unitOfWork.Commit();
                        return null;
                    }
               );
        }
    }
}
