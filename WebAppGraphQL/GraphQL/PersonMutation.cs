using GraphQL.Types;
using Model;
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

						var person = context.ArgumentAsProperties<PersonProperties>("person");

						return null;
					}
			   );
		}

	}


	public static class ResolveFieldContextExtension
	{
		/// <summary>
		/// casts implicitly to properties 
		/// https://github.com/graphql-dotnet/graphql-dotnet/blob/4df5e90d6aa8531b57671c89349b59e3dc084da1/src/GraphQL/ObjectExtensions.cs
		/// </summary>
		/// <typeparam name="TType"></typeparam>
		/// <param name="context"></param>
		/// <param name="name"></param>
		/// <returns>"properties object"</returns>
		public static TType ArgumentAsProperties<TType>(this ResolveFieldContext<object> context, string name)
			where TType : class, new()
		{
			if (context.Arguments.ContainsKey(name))
			{
				var input = context.Arguments[name] as Dictionary<string, object>;
				var type = typeof(TType);
				var obj = new TType();

				if (input != null)
					foreach (var item in input)
					{
						var fieldInfo = type.GetField(item.Key,
							BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
						if (fieldInfo != null)
						{
							if (item.Value == null)
							{

								var converter = fieldInfo.FieldType.GetMethod("op_Implicit", new[] { typeof(int?) });
								if (converter != null)
								{
									var value = converter.Invoke(null, new[] { item.Value });
									fieldInfo.SetValue(obj, value);
								}
							}
							else
							{
								var converter = fieldInfo.FieldType.GetMethod("op_Implicit", new[] { item.Value.GetType() });
								if (converter != null)
								{
									var value = converter.Invoke(null, new[] { item.Value });
									fieldInfo.SetValue(obj, value);
								}
							}


						}
					}
				return obj;
			}

			return null;
		}


	}


}