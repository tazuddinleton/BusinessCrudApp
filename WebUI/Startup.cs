using Autofac;
using BCrud.Core;
using BCrud.Domain.Dtos;
using BCrud.Persistence;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace WebUI
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

            //services.AddControllersWithViews().AddNewtonsoftJson()
            //    .AddJsonOptions(c=> { 
            //        c.JsonSerializerOptions.Converters.
            //    })

            
            services.AddControllersWithViews().AddNewtonsoftJson(configure => {                

                configure.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                configure.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                configure.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                configure.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                configure.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                configure.SerializerSettings.Formatting = Formatting.Indented;
                configure.SerializerSettings.Converters.Add(new StringEnumConverter());                  
            });
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
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
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller}/{action=Index}/{id?}");
            //});
            
            app.UseEndpoints(x => x.MapControllers());

            app.UseSpa(spa =>
            {


                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
