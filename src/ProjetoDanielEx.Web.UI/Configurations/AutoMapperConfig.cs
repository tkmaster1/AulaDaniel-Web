using Microsoft.Extensions.DependencyInjection;
using ProjetoDanielEx.Web.UI.AutoMapper;
using System;

namespace ProjetoDanielEx.Web.UI.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
