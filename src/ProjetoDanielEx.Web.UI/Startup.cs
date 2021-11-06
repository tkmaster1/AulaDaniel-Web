using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoDanielEx.Web.UI.Configurations;

namespace ProjetoDanielEx.Web.UI
{
    public class Startup
    {
        #region Propertries

        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _env;

        #endregion

        #region Constructor

        public Startup(IWebHostEnvironment hostEnvironment)
        //IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            //if (hostEnvironment.IsDevelopment())
            //{
            //    builder.AddUserSecrets<Startup>();
            //}
            _env = hostEnvironment;

            Configuration = builder.Build();
        }

        #endregion

        #region Methods

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapperConfiguration();

            services.AddHttpClient();

            //Allows auth to be bypassed
            if (_env.IsDevelopment())
                services.AddSingleton<IAuthorizationHandler, AllowAnonymous>();

            services.AddMvcConfiguration(Configuration);

            services.AddDependencyInjectionConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseGlobalizationConfig();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #endregion
    }
}
