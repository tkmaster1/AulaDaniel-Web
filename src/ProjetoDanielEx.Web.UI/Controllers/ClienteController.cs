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

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var clienteView = await ObterCliente(id);
            if (clienteView == null) { return NotFound(); }

            return View(clienteView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClienteViewModel cliente)
        {
            if (!ModelState.IsValid) return View(cliente);

            try
            {
                var clienteDomain = _mapper.Map<RequestAtualizarCliente>(cliente);
                await _unitOfWork.ClienteApp.Atualizar(clienteDomain);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return PartialView("Edit", cliente);
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> Delete()
        //{
        //    var clienteView = new ClienteViewModel();
        //    return View(clienteView);
        //}

        [HttpPost]
        public IActionResult DeleteConfirmed([FromBody] string objExcluirCliente)
        {
            var clienteView = new ClienteViewModel();

            //if (!ModelState.IsValid)
            //{
            //    clienteView.Mensagem = "Sem dados de formulário preenchidos!";
            //    return View(clienteView);
            //}

            //try
            //{
            //    await _unitOfWork.ClienteApp.Deletar(Convert.ToInt32(id));
            //    return Json(new { success = true });
            //}
            //catch (Exception ex)
            //{
            //    clienteView.Mensagem = ex.Message;
            return View("Delete", clienteView);
            //}
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

        private async Task<ClienteViewModel> ObterCliente(int id)
        {
            var response = await _unitOfWork.ClienteApp.ObterPorCodigo(id);

            var clienteView = _mapper.Map<ClienteDTO, ClienteViewModel>(response?.Data ?? new ClienteDTO());
            clienteView.ListaTipoPessoa = GetTipoPessoa();

            return clienteView;
        }

        #endregion
    }
}
