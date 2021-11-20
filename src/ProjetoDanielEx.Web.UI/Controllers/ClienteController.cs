using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoDanielEx.Web.UI.Application.DTO;
using ProjetoDanielEx.Web.UI.Application.Interfaces;
using ProjetoDanielEx.Web.UI.Application.Request.Cliente;
using ProjetoDanielEx.Web.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDanielEx.Web.UI.Controllers
{
    public class ClienteController : Controller
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

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

            return View(retorno);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ClienteViewModel();

            model.ListaTipoPessoa = GetTipoPessoa();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var clienteDomain = _mapper.Map<ClienteViewModel, RequestAdicionarCliente>(cliente);

                    var response = await _unitOfWork.ClienteApp.Adicionar(clienteDomain);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex;
                    return PartialView("Create", cliente);
                }
            }

            return PartialView(cliente);
        }

        #endregion

        #region Methods  

        public async Task<List<ClienteViewModel>> ListarTodos()
        {
            var response = await _unitOfWork.ClienteApp.ListarTodos();

            return _mapper.Map<List<ClienteViewModel>>(response?.Data.ToList() ?? new List<ClienteDTO>());
        }

        #endregion

        #region Métodos Privados

        private Dictionary<string, string> GetTipoPessoa()
        {
            return new Dictionary<string, string>
            {
                {"f", "Pessoa Física"},
                {"j", "Pessoa Jurídica"}
            };
        }

        #endregion
    }
}
