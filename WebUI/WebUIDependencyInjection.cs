using AutoMapper;
using TDJ.WebUI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using TSJ.Infraestructure.Identity;
using TSJ.Infraestructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Helpers;
using System.Net;
//using TDJ.WebUI.Connected_Services.WebServiceFirma.IWebService;
//using TDJ.WebUI.HelpersWeb;

namespace TDJ.WebUI
{
    public static class WebUIDependencyInjection
    {
        public static IServiceCollection AddWebUI(this IServiceCollection services)
        {
            //services.Configure<ForwardedHeadersOptions>(options =>
            //{
            //    options.KnownProxies.Add(IPAddress.Parse("10.75.55.49"));
            //});

            services.AddAuthentication();
            services.AddAuthorization();

            //Se implementa la política, con la dirección de donde se va a consumir
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://efirma.tsjqroo.gob.mx"));
            });

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(UserFilterAttribute));
                //options.Filters.Add(typeof(CustomAuthorizationFilter));
            });

            services.AddControllersWithViews();

            services.AddRazorPages();
            services.AddMvcJQueryDataTables();
            services.AddAutoMapper(typeof(Startup));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();


            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            var authorizeFilter = new AuthorizeFilter(policy);
            services.AddMvcCore(opts =>
            {
                var context = services.BuildServiceProvider().GetService<Con57DbContext>();
                opts.Filters.Add(authorizeFilter); // Authorize for all controllers
                //opts.Conventions.Add(new AuthorizeControllerModelConvention(context));
                opts.ModelMetadataDetailsProviders.Add(new CustomValidationMetadataProvider());

            });
            services.AddDistributedMemoryCache();
            services.AddSession();
            //services.AddScoped<IWebServiceFirma, Connected_Services.WebServiceFirma.WebService.WebServiceFirma>();
            return services;

            #region Original
            /*
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(UserFilterAttribute));
            }
            );
            services.AddRazorPages();

            services.AddMvcJQueryDataTables();
            services.AddAutoMapper(typeof(Startup));

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            var authorizeFilter = new AuthorizeFilter(policy);
            services.AddMvcCore(opts =>
            {
                opts.Filters.Add(authorizeFilter); // Authorize for all controllers
            });

            services.AddMemoryCache();
            services.AddSession();

            services.AddAuthorization();

            return services;
            */
            #endregion
        }
    }
}