using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoDanielEx.Web.UI.Application.DTO;
using ProjetoDanielEx.Web.UI.Application.Interfaces;
using ProjetoDanielEx.Web.UI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDanielEx.Web.UI.Controllers
{
    public class ClienteController : Controller
    {
        #region Properties

        //  private readonly ILogger<ClienteController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        //ILogger<ClienteController> logger)

        public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Views        

        public async Task<IActionResult> Index()
        {
            var retorno = await ListarTodos();
            //var response = await _unitOfWork.ClienteApp.ListarTodos();
            //var retorno = _mapper.Map<List<ClienteViewModel>>(response?.Data.ToList() ?? new List<ClienteDTO>());

            return View("Index", retorno);
        }

        #endregion

        #region Methods  

        public async Task<List<ClienteViewModel>> ListarTodos()
        {
            var response = await _unitOfWork.ClienteApp.ListarTodos();

            var retorno = _mapper.Map<List<ClienteViewModel>>(response?.Data.ToList() ?? new List<ClienteDTO>());

            return retorno; //View("Index", retorno);

            //var retorno = _mapper.Map<List<ClienteViewModel>>(response?.Data.ToList() ?? new List<ClienteDTO>());

            // return Ok(retorno);
        }

        #endregion
    }
}
