using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Name = "person";
            Field(x => x.ID).Description("Person Id");
            Field(x => x.FirstName).Description("Person First Name");
            Field(x => x.LastName).Description("Person Last Name");
            Field(x => x.Age).Description("Person Age");
            Field<ListGraphType<CompanyType>>("Companies");
            Field<ListGraphType<ProjectType>>("Projects");
            Field<ListGraphType<PersonSkillType>>("PersonSkills");
            Field<ListGraphType<EducationType>>("Educations");

        }
    }
}
