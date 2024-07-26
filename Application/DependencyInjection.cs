using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Auto Mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            // MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

    }
}
