using Microsoft.Extensions.Configuration;

namespace ProjetoDanielEx.Web.UI.Application.BaseService
{
    public class Application
    {
        public Application()
        {
            IConfiguration _configuration = new ConfigurationBuilder()
                                                .AddJsonFile("AppSettings.json").Build();
            Version = _configuration["AppSettings:Application:Version"];
        }

        public string Version { get; set; }
    }
}
