using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Http;
using GraphQL.Types;
using GraphQL;
using Model;
using WebAppGraphQL.Middleware;
using Repository;
using WebAppGraphQL.GraphQL;

namespace WebAppGraphQL
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddSingleton<PersonType>();
            services.AddSingleton<SkillType>();
            services.AddSingleton<CompanyType>();
            services.AddSingleton<ProjectType>();
            services.AddSingleton<EducationType>();
            services.AddSingleton<PersonQuery>();
            services.AddSingleton<PositionType>();
            services.AddSingleton<DurationType>();
            services.AddSingleton<PersonSkillType>();
            services.AddSingleton<ISchema>(s => new PersonSchema(type => (GraphType)s.GetService(type)));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var d = app.ApplicationServices.GetService<ISchema>();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseGraphQLEndpoint();
            
        }
    }
   
}
