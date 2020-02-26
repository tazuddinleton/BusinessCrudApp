using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Persistence
{
    public static class Extensions
    {
        public static void AddPersistence(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterType<DatabaseContext>()
                .InstancePerLifetimeScope()
                .WithParameter("connectionString", configuration.GetConnectionString("bcrud"));
        }
    }
}

