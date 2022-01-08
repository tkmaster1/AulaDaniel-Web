using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoDanielEx.Web.UI.Areas.Identity.Data;

namespace ProjetoDanielEx.Web.UI.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

                //options.UserLockoutEnabledByDefault = true;
                //options.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5); // lockout timespan
                //options.MaxFailedAccessAttemptsBeforeLockout = 5;

            });

            services.AddDbContext<AspNetCoreIdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AspNetCoreIdentityContextConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddEntityFrameworkStores<AspNetCoreIdentityContext>();

            //// Configure user lockout defaults
            //services.UserLockoutEnabledByDefault = true;
            //services.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5); // lockout timespan
            //services.MaxFailedAccessAttemptsBeforeLockout = 5; // number of failed login attempts before lockout

            return services;
        }
    }
}
