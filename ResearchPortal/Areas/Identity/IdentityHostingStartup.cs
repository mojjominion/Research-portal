using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ResearchPortal.Areas.Identity.IdentityHostingStartup))]
namespace ResearchPortal.Areas.Identity
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