using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Persistence
{
    public static class Extensions
    {
        public static void RegisterDbContext(this ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>()
                .InstancePerLifetimeScope();
        }
    }
}

