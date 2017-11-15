using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Reflection;

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

						var person = context.ArgumentAsProperty<PersonProperties>("person");

						return null;
					}
			   );
		}
		private PersonProperties Map(PersonInput input)
		{


			var properties = new PersonProperties();
			properties.Age = null;
			properties.FirstName = "adfd";
			properties.LastName = null;
			//properties.FirstName = properties.Set<string>(input.FirstName);
			//properties.LastName= properties.Set<string>(input.LastName);
			//properties.Age= properties.Set<int?>(input.Age);
			//Set<string>(input.FirstName, ref properties.FirstName);
			//Set<string>(input.LastName, ref properties.LastName);
			//Set<int?>(input.Age, ref properties.Age);

			//properties.Courses = input.Courses != null ? input.Courses.Select(x => new CourseProperties() { Id = x.Id }).ToList() : properties.Courses;
			return properties;
		}
		//private void Set<T>(T input, ref Property<T> output)
		//{

		//    if (input != null)
		//    {
		//        output = input;
		//    }
		//    else
		//    {
		//        output = null;
		//    }
		//}






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

	public static class ResolveFieldContextExtensions
	{
		public static TType ArgumentAsProperty<TType>(this ResolveFieldContext<object> context, string name)
			where TType : class, new()
		{
			if (context.Arguments.ContainsKey(name))
			{
				var input = context.Arguments[name] as Dictionary<string, object>;

				var type = typeof(TType);

				var obj = Activator.CreateInstance(type);

				if (input != null)
					foreach (var item in input)
					{
						var fieldInfo = type.GetField(item.Key,
							BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
						if (fieldInfo != null)
						{

							//Type generic = typeof(Property<>).MakeGenericType(fieldInfo.FieldType);
							//object o = Activator.CreateInstance(generic);
							//generic.GetProperty("Value")?.SetValue(o, item.Value, null);


							fieldInfo.SetValue(obj, Convert.ChangeType(item.Value, fieldInfo.FieldType));




						}
					}
			}

			return null;
		}


	}


}