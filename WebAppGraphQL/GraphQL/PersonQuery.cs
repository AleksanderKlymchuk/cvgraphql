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
           
            Field<ListGraphType<PersonType>>(
                "person",
                arguments: new QueryArguments(
                     new QueryArgument<StringGraphType>() { Name = "orderby" }

                    ),

                     resolve: context =>
                     {
                         var orderby = context.GetArgument<string>("orderby");

                         var data= unitOfWork.Persons.GetAll(orderby);

                         return data;
                        
                     }
                );
          
        }
    }
}
