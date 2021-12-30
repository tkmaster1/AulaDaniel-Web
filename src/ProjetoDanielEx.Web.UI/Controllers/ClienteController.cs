using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoDanielEx.Web.UI.Application.DTO;
using ProjetoDanielEx.Web.UI.Application.Interfaces;
using ProjetoDanielEx.Web.UI.Application.Request.Cliente;
using ProjetoDanielEx.Web.UI.Util;
using ProjetoDanielEx.Web.UI.ViewModel;
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
            var model = new ClienteViewModel
            {
                ListaTipoPessoa = GetTipoPessoa()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel cliente)
        {
            string mensagem = string.Empty;
            var cpfcnpj = ValidarCPFCNPJ(ValidationCPFCNPJ.SemFormatacaoCPFCNPJ(cliente.Documento));

            if (!string.IsNullOrEmpty(cpfcnpj))
            {
                return Json(new { success = false, mensagem = cpfcnpj });
            }

            var nomeExiste = await _unitOfWork.ClienteApp.NomeExiste(cliente.Nome);
            if (nomeExiste.Data != null)
            {
                mensagem = Mensagens.MSG_NOME_CLIENTE.ToFormat(cliente.Nome);
                return Json(new { success = false, mensagem = mensagem });
            }

            if (!string.IsNullOrEmpty(cliente.Documento))
            {
                var documentoExiste = await _unitOfWork.ClienteApp.DocumentoExiste(ValidationCPFCNPJ.SemFormatacaoCPFCNPJ(cliente.Documento));
                if (documentoExiste.Data != null)
                {
                    mensagem = Mensagens.MSG_DOCUMENTO_CLIENTE.ToFormat(cliente.Documento);
                    return Json(new { success = false, mensagem = mensagem });
                }
            }
            else
            {
                mensagem = Mensagens.MSG_VALIDARCPFCNPJ_FALHA.ToFormat("CNPJ");
                return Json(new { success = false, mensagem = mensagem });
            }

            var clienteDomain = _mapper.Map<ClienteViewModel, RequestAdicionarCliente>(cliente);
            var response = await _unitOfWork.ClienteApp.Adicionar(clienteDomain);

            if (response.Data.ToString().Length <= 0)
                mensagem = Mensagens.MSG_FALHA.ToFormat("Incluir", "o Cliente");
            else
                mensagem = Mensagens.MSG_SUCESSO.ToFormat("realizada", "Inclusão");

            return Json(new { success = true, mensagem = mensagem });
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
            string mensagem = string.Empty;

            var cpfcnpj = ValidarCPFCNPJ(ValidationCPFCNPJ.SemFormatacaoCPFCNPJ(cliente.Documento));
            if (!string.IsNullOrEmpty(cpfcnpj))
            {
                return Json(new { success = false, mensagem = cpfcnpj });
            }
            else
            {
                if (cliente.Documento.Equals(@"00.000.000/0000-00"))
                {
                    mensagem = Mensagens.MSG_VALIDARCPFCNPJ_FALHA.ToFormat("CNPJ");
                    return Json(new { success = false, mensagem = mensagem });
                }
            }

            var clienteDomain = _mapper.Map<RequestAtualizarCliente>(cliente);
            var response = await _unitOfWork.ClienteApp.Atualizar(clienteDomain);

            if (!(bool)response.Data)
                mensagem = Mensagens.MSG_FALHA.ToFormat("Editar", "o Cliente");
            else
                mensagem = Mensagens.MSG_SUCESSO.ToFormat("realizada", "Edição");

            return Json(new { success = true, mensagem = mensagem });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int codigo)
        {
            string mensagem = string.Empty;

            var response = await _unitOfWork.ClienteApp.Deletar(new RequestReativarExcluirCliente()
            {
                Codigo = codigo
            });

            if (!(bool)response.Data)
                mensagem = Mensagens.MSG_FALHA.ToFormat("excluir", "o Cliente");
            else
                mensagem = Mensagens.MSG_SUCESSO.ToFormat("excluído", "Cliente");

            return Json(new { success = true, mensagem = mensagem });
        }

        [HttpGet]
        public async Task<IActionResult> Reativar(int codigo)
        {
            string mensagem = string.Empty;

            var response = await _unitOfWork.ClienteApp.Reativar(new RequestReativarExcluirCliente()
            {
                Codigo = codigo
            });

            if (!(bool)response.Data)
                mensagem = Mensagens.MSG_FALHA.ToFormat("reativar", "o Cliente");
            else
                mensagem = Mensagens.MSG_SUCESSO.ToFormat("reativado", "Cliente");

            return Json(new { success = true, mensagem = mensagem });
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
            var response = await _unitOfWork.ClienteApp.ObterClienteEndereco(id);
            var clienteView = _mapper.Map<ClienteDTO, ClienteViewModel>(response?.Data ?? new ClienteDTO());
            clienteView.ListaTipoPessoa = GetTipoPessoa();
            return clienteView;
        }

        private string ValidarCPFCNPJ(string cpfcnpj)
        {
            switch (cpfcnpj.Length)
            {
                case 11:
                    if (!ValidationCPFCNPJ.ValidaCPF(cpfcnpj))
                        return Mensagens.MSG_VALIDARCPFCNPJ_FALHA.ToFormat("CPF");
                    break;
                default:
                    if (!ValidationCPFCNPJ.ValidaCNPJ(cpfcnpj))
                        return Mensagens.MSG_VALIDARCPFCNPJ_FALHA.ToFormat("CNPJ");
                    break;
            }

            return string.Empty;
        }

        #endregion
    }
}
