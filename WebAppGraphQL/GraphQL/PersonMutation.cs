using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PersonMutation : ObjectGraphType<object>
    {
        public PersonMutation(IUnitOfWork unitOfWork)
        {
            Field<PersonType>(
               "createPersonCV",
                    arguments: new QueryArguments(
                         new QueryArgument<PersonInputType>() { Name = "person" }
                        ),
                    resolve: context =>
                    {

                        var person = context.GetArgument<PersonInput>("person");
                        var data = Map(person);
                        //unitOfWork.Persons.Add(person);
                        //unitOfWork.Commit();
                        return null;
                    }
               );
        }
        private PersonProperties Map(PersonInput input)
        {
            var properties = new PersonProperties();
            properties.Set<string>(input.FirstName, ref properties.FirstName);
            properties.Set<string>(input.LastName, ref properties.LastName);
            properties.Set<int?>(input.Age, ref properties.Age);
            properties.Courses=input.Courses!=null?input.Courses.Select(x=>new CourseProperties() { Id=x.Id}).ToList():properties.Courses;
            return properties;
        }


        public class PersonInput
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int? Age { get; set; }
            public List<CourseInput> Courses { get; set; }
        }
        public class CourseInput
        {
            public int Id { get; set; }
        }
    }
}