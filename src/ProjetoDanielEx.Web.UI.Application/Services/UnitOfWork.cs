using Microsoft.AspNetCore.Http;
using ProjetoDanielEx.Web.UI.Application.BaseService.Interfaces;
using ProjetoDanielEx.Web.UI.Application.Interfaces;

namespace ProjetoDanielEx.Web.UI.Application.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties

        private readonly IBaseService _baseService;
        private readonly IHttpContextAccessor _context;

        #endregion

        #region Constructor

        public UnitOfWork(IBaseService baseService, 
                          IHttpContextAccessor context)
        {
            _baseService = baseService;
            _context = context;
        }

        #endregion

        #region Instância Privadas

        private IClienteAppService clienteApp;

        #endregion

        #region Propriedades Públicas

        public IClienteAppService ClienteApp
        {
            get { return clienteApp ?? new ClienteAppService(_baseService); }
        }

        #endregion
    }
}
