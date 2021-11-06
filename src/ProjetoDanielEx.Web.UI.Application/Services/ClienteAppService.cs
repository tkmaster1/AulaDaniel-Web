using ProjetoDanielEx.Web.UI.Application.BaseService.Interfaces;
using ProjetoDanielEx.Web.UI.Application.DTO;
using ProjetoDanielEx.Web.UI.Application.Interfaces;
using ProjetoDanielEx.Web.UI.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var response = await _service.MontarResponseList<ClienteDTO>(request);
            return response;
        }

        public async Task<RetornoAPIData<ClienteDTO>> ObterPorCodigo(int codigo)
        {
            string url = $"{_service.UrlBase}/Cliente/ObterPorCodigo/{codigo.ToString()}";

            var request = _service.MontarRequest("GET", url);

            var response = await _service.MontarResponse<ClienteDTO>(request);

            return response;
        }

        #endregion
    }
}
