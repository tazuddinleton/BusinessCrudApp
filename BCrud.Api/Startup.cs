using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using BCrud.Core;
using BCrud.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BCrud.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ILifetimeScope Container { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(configure => {
                    configure.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    configure.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    configure.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                    configure.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    configure.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    configure.SerializerSettings.Formatting = Formatting.Indented;
                    configure.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsImplementedInterfaces();
            builder.RegisterDbContext();
            builder.RegisterRepositories();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
