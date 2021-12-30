using ProjetoDanielEx.Web.UI.Application.DTO;
using ProjetoDanielEx.Web.UI.Application.Request.Cliente;
using ProjetoDanielEx.Web.UI.Application.Response;
using System.Threading.Tasks;

namespace ProjetoDanielEx.Web.UI.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<RetornoAPIDataList<ClienteDTO>> ListarTodos();

        Task<RetornoAPIData<ClienteDTO>> ObterPorCodigo(int codigo);

        Task<RetornoAPIData<object>> Adicionar(RequestAdicionarCliente req);

        Task<RetornoAPIData<object>> Atualizar(RequestAtualizarCliente requestAtualizar);

        Task<RetornoAPIData<object>> Deletar(RequestReativarExcluirCliente req);

        Task<RetornoAPIData<object>> Reativar(RequestReativarExcluirCliente req);

        Task<RetornoAPIData<ClienteDTO>> NomeExiste(string nomeCliente);

        Task<RetornoAPIData<ClienteDTO>> DocumentoExiste(string documento);

        Task<RetornoAPIData<ClienteDTO>> ObterClienteEndereco(int codigo);
    }
}
