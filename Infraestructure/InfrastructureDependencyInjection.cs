using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TSJ.Application.Interfaces;
using TSJ.Infraestructure.Persistence;
using TSJ.Infraestructure.Email;
using TSJ.Infraestructure.Ldap;

namespace TSJ.Infraestructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var assemblyToScan = Assembly.GetAssembly(typeof(TSJ.Infraestructure.Services.AccountService)); //..or whatever assembly you need

            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
                  .Where(c => c.Name.EndsWith("Service"))
                  .AsPublicImplementedInterfaces();

            services.AddScoped<IAuthenticationService, LdapAuthenticationService>();

            services.AddScoped<IEMailService, EMailService>();

            return services;

        }
    }
}