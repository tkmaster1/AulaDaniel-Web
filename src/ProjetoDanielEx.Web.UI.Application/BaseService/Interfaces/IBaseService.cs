using ProjetoDanielEx.Web.UI.Application.Response;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoDanielEx.Web.UI.Application.BaseService.Interfaces
{
    public interface IBaseService
    {
        string UrlBase { get; }

        string MontarParametros(string[] parametros);

        HttpRequestMessage MontarRequest(string metodo, string url, object parametros = null);

        Task<RetornoAPIDataList<T>> MontarResponseList<T>(HttpRequestMessage request) where T : class;

        Task<RetornoAPIData<T>> MontarResponse<T>(HttpRequestMessage request) where T : class;

        Task<RetornoAPIData<KeyValuePair<object, string>>> MontarResponseRegraNegocio(HttpRequestMessage request);
    }
}
