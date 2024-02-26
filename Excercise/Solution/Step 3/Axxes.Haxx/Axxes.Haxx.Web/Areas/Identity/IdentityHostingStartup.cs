using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Axxes.Haxx.Web.Areas.Identity.IdentityHostingStartup))]
namespace Axxes.Haxx.Web.Areas.Identity
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