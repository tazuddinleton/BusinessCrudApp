using Autofac;
using BCrud.Core.Repositories;
using BCrud.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Core
{
    public static class Extensions
    {
        public static void AddApplicationCore(this ContainerBuilder builder)
        {
            builder.RegisterType<TradeRepository>().As<ITradeRepository>();
            builder.RegisterType<TradeLevelRepository>().As<ITradeLevelRepository>();
            builder.RegisterType<SyllabusRepository>().As<ISyllabusRepository>();
        }
    }
}

