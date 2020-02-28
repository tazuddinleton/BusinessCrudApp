using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BCrud.Api.Common
{
    public static class Extensions
    {
        public static T BindId<T>(this T model, Expression<Func<T, Guid>> expression)
            => model.Bind<T, Guid>(expression, Guid.NewGuid());

        public static T Bind<T>(this T model, Expression<Func<T, object>> expression, object value)
            => model.Bind<T, object>(expression, value);

        private static TModel Bind<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression, object value)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            var propertyName = memberExpression.Member.Name.ToLowerInvariant();
            var modelType = model.GetType();

            var field = modelType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .SingleOrDefault(x => x.Name.ToLowerInvariant()
                .StartsWith($"<{propertyName}>"));
            if (field == null)
                return model;
            field.SetValue(model, value);
            return model;
        }

        public static IMvcBuilder AddCustomNewtonSoftJson(this IMvcBuilder builder)
        {
            builder.AddNewtonsoftJson(configure => {
                 configure.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                 configure.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                 configure.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                 configure.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                 configure.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 configure.SerializerSettings.Formatting = Formatting.Indented;
                 configure.SerializerSettings.Converters.Add(new StringEnumConverter());
             });
            return builder;
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            return services.AddCors(opt => opt.AddPolicy("allowallorigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        }
    }
}
