using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProjetoDanielEx.Web.UI.Application.BaseService;

namespace ProjetoDanielEx.Web.UI.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services, IConfiguration configuartion)
        {
            services.AddControllersWithViews(o =>
            {                
                o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            services.AddControllers();

            services.AddRazorPages();

            var _appConfig = configuartion.GetSection("AppSettings").Get<ApplicationConfig>();

            services.AddSingleton(_appConfig);
            services.Configure<ApplicationConfig>(configuartion.GetSection("AppSettings"));

            // services.AddTransient<AppSettings>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddCors();

            return services;
        }
    }
}
