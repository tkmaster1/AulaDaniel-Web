using ProjetoDanielEx.Web.UI.Application.BaseService.Interfaces;
using ProjetoDanielEx.Web.UI.Application.DTO;
using ProjetoDanielEx.Web.UI.Application.Interfaces;
using ProjetoDanielEx.Web.UI.Application.Request.Cliente;
using ProjetoDanielEx.Web.UI.Application.Response;
using System.Threading.Tasks;

namespace ProjetoDanielEx.Web.UI.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        #region Properties

        private readonly IBaseService _service;

        #endregion

        #region Constructor

        public ClienteAppService(IBaseService service)
        {
            _service = service;
        }

        #endregion

        #region Methods

        public async Task<RetornoAPIDataList<ClienteDTO>> ListarTodos()
        {
            string url = $"{_service.UrlBase}/Cliente/ListarTodos";

            var request = _service.MontarRequest("GET", url);

            return await _service.MontarResponseList<ClienteDTO>(request);
        }

        public async Task<RetornoAPIData<ClienteDTO>> ObterPorCodigo(int codigo)
        {
            string url = $"{_service.UrlBase}/Cliente/ObterPorCodigo/{codigo.ToString()}";

            var request = _service.MontarRequest("GET", url);

            return await _service.MontarResponse<ClienteDTO>(request);
        }

        public async Task<RetornoAPIData<object>> Adicionar(RequestAdicionarCliente req)
        {
            string url = $"{_service.UrlBase}/Cliente/Adicionar/";

            var request = _service.MontarRequest("POST", url, req);

            return await _service.MontarResponse<object>(request);
        }

        public async Task<RetornoAPIData<object>> Atualizar(RequestAtualizarCliente requestAtualizar)
        {
            string url = $"{_service.UrlBase}/Cliente/Atualizar/";

            var request = _service.MontarRequest("PUT", url, requestAtualizar);

            return await _service.MontarResponse<object>(request);
        }

        public async Task<RetornoAPIData<object>> Deletar(int codigo)
        {
            string url = $"{_service.UrlBase}/Cliente/Excluir?{codigo}";

            var request = _service.MontarRequest("PUT", url);

            return await _service.MontarResponse<object>(request);
        }
        #endregion
    }
}
