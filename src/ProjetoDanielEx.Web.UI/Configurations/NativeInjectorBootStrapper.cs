using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProjetoDanielEx.Web.UI.Application.BaseService;
using ProjetoDanielEx.Web.UI.Application.BaseService.Interfaces;
using ProjetoDanielEx.Web.UI.Application.Interfaces;
using ProjetoDanielEx.Web.UI.Application.Services;

namespace ProjetoDanielEx.Web.UI.Configurations
{
    public abstract class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Lifestyle.Transient => Uma instância para cada solicitação
            // Lifestyle.Singleton => Uma instância única para a classe (para servidor)
            // Lifestyle.Scoped => Uma instância única para o request

            services.AddScoped<IBaseService, BaseService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();

            services.AddTransient<IClienteAppService, ClienteAppService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
