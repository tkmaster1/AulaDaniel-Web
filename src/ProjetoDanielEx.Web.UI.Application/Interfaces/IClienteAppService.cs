using ProjetoDanielEx.Web.UI.Application.DTO;
using ProjetoDanielEx.Web.UI.Application.Response;
using System.Threading.Tasks;

namespace ProjetoDanielEx.Web.UI.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<RetornoAPIDataList<ClienteDTO>> ListarTodos();

        Task<RetornoAPIData<ClienteDTO>> ObterPorCodigo(int codigo);

        //Task<RetornoAPIDataList<ClienteDTO>> ListarTodos();

        //Task<RetornoAPIDataList<ClienteDTO>> ListarTodos();

        //Task<RetornoAPIDataList<ClienteDTO>> ListarTodos();
    }
}
