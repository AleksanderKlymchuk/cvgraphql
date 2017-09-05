using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppGraphQL.GraphQL;

namespace WebAppGraphQL.Middleware
{
    public class GraphQLEndpointMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPersonRepository _personRepository;
        private readonly ISchema _schema;
        public GraphQLEndpointMiddleware(RequestDelegate next, IPersonRepository personRepository, ISchema schema)
        {
            _next = next;
            _schema = schema;
            if (personRepository == null) throw new ArgumentNullException("personRepository");
            _personRepository = personRepository;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Path.StartsWithSegments("/cvgraph"))
            {
                using (StreamReader reader = new StreamReader(context.Request.Body))
                {
                    var query = await reader.ReadToEndAsync();
                    if (string.IsNullOrEmpty(query))
                    {
                        await context.Response.WriteAsync("query are not valid");
                    }
                    else
                    {
                        try
                        {
                            var request = JsonConvert.DeserializeObject<GraphQLRequest>(query);
                           
                            var result = await new DocumentExecuter().ExecuteAsync(options =>
                            {
                                options.Schema = _schema;
                                options.Query = request.Query;
                                options.OperationName = request.OperationName;
                                options.Inputs = request.Variables.ToInputs();


                            }).ConfigureAwait(false);
                            var json = new DocumentWriter(indent: true).Write(result);
                            await context.Response.WriteAsync(json);
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                      
                       
                    }
                }
            }
            else if (context.Request.Path.StartsWithSegments("/cvgraph-schema"))
            {
                string schema = @"
                                {
                                  person(firstName:"",lastName:"") {
                                    id
                                    firstName
                                    lastName
                                    age
                                    companies{
                                        id
                                        name
                                        positions {
                                            id,
                                            title
                                            duration{
                                                    start
                                                    end
                                            }
                                            description
                                        }
                                    }
                                    educations{
                                        id
                                        title
                                        institutionName
                                        specialization
                                        start
                                        end
                                    }
                                    personSkills{
                                        skill{
                                            name
                                        }
                                        level
                                    }
                                    projects{
                                        id
                                        name
                                    }
                                 }
                              } ";

                await context.Response.WriteAsync(schema);
            }
            else if (context.Request.Path.StartsWithSegments("/"))
            {
                await context.Response.WriteAsync("Curriculum Vitae Backend Service");
            }
            else
            {
               await this._next(context);
            }
        }
    }

    public static class GraphQLEndpointMiddlewareExtensions
    {
        public static IApplicationBuilder UseGraphQLEndpoint(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GraphQLEndpointMiddleware>();
        }
    }
}
