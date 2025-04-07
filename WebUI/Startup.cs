using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TSJ.Domain.Entities;
using TSJ.Application.Ldap;
using TSJ.Infraestructure;
using TSJ.Infraestructure.Persistence;

using NetCore.AutoRegisterDi;
using System.Reflection;
using TSJ.Application.Interfaces;
using TSJ.Infraestructure.Ldap;
using System.Net;
using Microsoft.AspNetCore.HttpOverrides;

namespace TDJ.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseNpgsql(Configuration.GetConnectionString("Con57")).UseSnakeCaseNamingConvention());
            
            services.AddDbContext<Con57DbContext>(options =>
                        options.UseNpgsql(Configuration.GetConnectionString("Con57"), 
                                          m => m.MigrationsAssembly("TSJ.Infraestructure")).UseSnakeCaseNamingConvention());

            services.Configure<LdapConfig>(Configuration.GetSection("Ldap"));
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));

            services.AddInfrastructure();
            services.AddWebUI();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            //app.UsePathBase("/tdj");
            app.UseStaticFiles();
            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); /*Agregar MapRazorPages si no se redirecciona al login del identity.*/
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}