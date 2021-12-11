using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using ProjetoDanielEx.Web.UI.Application.BaseService.Interfaces;
using ProjetoDanielEx.Web.UI.Application.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDanielEx.Web.UI.Application.BaseService
{
    public class BaseService : IBaseService, IDisposable
    {
        #region Properties

        private bool _disposed = false;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        private readonly IHttpContextAccessor _httpContextHttp;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApplicationConfig _appConfig;
        private readonly NotificationHandler _notifications;

        public string UrlBase { get; protected set; }

        #endregion

        #region Constructor

        public BaseService(IHttpContextAccessor httpContextHttp,
             IHttpClientFactory httpClientFactory,
             IOptions<ApplicationConfig> appConfig,
             INotificationHandler<Notification> notifications
            )
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpContextHttp = httpContextHttp;
            _httpClientFactory = httpClientFactory;
            _appConfig = appConfig.Value;
            UrlBase = _appConfig.BaseUrl.UrlApi;
            _notifications = (NotificationHandler)notifications;
        }

        #endregion

        #region Methods

        public HttpClient MontarHttpClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Clear();

            client.BaseAddress = new Uri(UrlBase);

            #region OldToken
            //var client = _httpClientFactory.CreateClient(_appConfig.Authentication.RHSSO.ClientApiId);
            //client.DefaultRequestHeaders.Clear();
            //var tokenString = _httpContextHttp.HttpContext.GetTokenAsync("access_token").Result;

            //if (!string.IsNullOrEmpty(tokenString))
            //    client.SetBearerToken(_httpContextHttp.HttpContext.GetTokenAsync("access_token").Result);
            #endregion

            return client;
        }

        public string MontarParametros(string[] parametros)
        {
            var retorno = parametros == null ? ""
                        : parametros.Length > 1
                            ? ("?" + string.Join("&", parametros))
                            : parametros.Length == 1
                        ? (parametros[0]) : "";

            return retorno;
        }

        public HttpRequestMessage MontarRequest(string metodo, string url, object parametros = null)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(url);

            switch (metodo)
            {
                case "GET":
                    request.Method = HttpMethod.Get;
                    return request;

                case "PUT":
                    request.Method = HttpMethod.Put;
                    request.Content = new StringContent(JsonConvert.SerializeObject(parametros), Encoding.UTF8, "application/json");
                    return request;

                case "POST":
                    request.Method = HttpMethod.Post;
                    request.Content = new StringContent(JsonConvert.SerializeObject(parametros), Encoding.UTF8, "application/json");
                    return request;

                case "DELETE":
                    request.Method = HttpMethod.Delete;
                    return request;

                default:
                    break;
            }

            return request;
        }

        public async Task<RetornoAPIDataList<T>> MontarResponseList<T>(HttpRequestMessage request) where T : class
        {
            var client = MontarHttpClient();

            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<RetornoAPIDataList<T>>(responseBody);

                if (!response.IsSuccessStatusCode)
                {
                    await _notifications.Handle(new Notification(response?.StatusCode.ToString() ?? "500",
                                                                    response?.StatusCode.ToString() == "Unauthorized"
                                                                        ? "Unauthorized"
                                                                        : retorno?.Errors?.ToString() ?? "" + " : " + request.RequestUri.AbsolutePath));
                }

                return retorno;
            }
        }

        public async Task<RetornoAPIData<T>> MontarResponse<T>(HttpRequestMessage request) where T : class
        {

            var client = MontarHttpClient();

            using (HttpResponseMessage response = await client.SendAsync(request))
            {

                string responseBody = await response.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<RetornoAPIData<T>>(responseBody);

                if (!response.IsSuccessStatusCode)
                {
                    await _notifications.Handle(new Notification(response?.StatusCode.ToString() ?? "500",
                                                                   response?.StatusCode.ToString() == "Unauthorized"
                                                                        ? "Unauthorized"
                                                                        : retorno?.Errors?.ToString() ?? "" + " : " + request.RequestUri.AbsolutePath));
                }

                return retorno;
            }
        }

        public async Task<RetornoAPIData<KeyValuePair<object, string>>> MontarResponseRegraNegocio(HttpRequestMessage request)
        {
            var client = MontarHttpClient();

            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<RetornoAPIData<KeyValuePair<object, string>>>(responseBody);

                if (!response.IsSuccessStatusCode)
                {
                    await _notifications.Handle(new Notification(response?.StatusCode.ToString() ?? "500",
                                                                   response?.StatusCode.ToString() == "Unauthorized"
                                                                        ? "Unauthorized"
                                                                        : retorno?.Errors?.ToString() ?? "" + " : " + request.RequestUri.AbsolutePath));
                }

                return retorno;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _safeHandle?.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
