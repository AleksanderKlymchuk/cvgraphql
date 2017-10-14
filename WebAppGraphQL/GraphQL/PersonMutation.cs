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
            properties.FirstName.Set(input.FirstName);// = //properties.Set<string>(input.FirstName);
            properties.LastName= properties.Set<string>(input.LastName);
            properties.Age= properties.Set<int?>(input.Age);
            //Set<string>(input.FirstName, ref properties.FirstName);
            //Set<string>(input.LastName, ref properties.LastName);
            //Set<int?>(input.Age, ref properties.Age);

            //properties.Courses = input.Courses != null ? input.Courses.Select(x => new CourseProperties() { Id = x.Id }).ToList() : properties.Courses;
            return properties;
        }
        private void Set<T>(T input, ref Property<T> output)
        {
            var prop = this.GetType().GetProperty(nameof(output));

            if (input != null)
            {
                output = input;
            }
            else
            {
                output = null;
            }
        }



        

       
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

    //public static class Extensions
    //{
    //    public static Property<T> Set<T>(this Property<T> prop,T input)
    //    {
    //        if (input != null)
    //        {
    //            prop = input;
    //            return prop.Value;
    //        }
    //        return prop;
    //    }
    //}
}