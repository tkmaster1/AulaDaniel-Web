using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ProjetoDanielEx.Web.UI.Areas.Identity.IdentityHostingStartup))]
namespace ProjetoDanielEx.Web.UI.Areas.Identity
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