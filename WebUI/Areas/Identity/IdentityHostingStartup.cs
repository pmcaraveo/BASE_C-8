using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TDJ.WebUI.Areas.Identity.IdentityHostingStartup))]
namespace TDJ.WebUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}