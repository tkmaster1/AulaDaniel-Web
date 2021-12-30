using AutoMapper;
using ProjetoDanielEx.Web.UI.Application.DTO;
using ProjetoDanielEx.Web.UI.Application.Request.Cliente;
using ProjetoDanielEx.Web.UI.ViewModel;

namespace ProjetoDanielEx.Web.UI.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // Cliente
            CreateMap<ClienteViewModel, ClienteDTO>();
            CreateMap<ClienteViewModel, RequestAdicionarCliente>();
            CreateMap<ClienteViewModel, RequestAtualizarCliente>();

            // Endereco
            CreateMap<EnderecoViewModel, EnderecoDTO>().ReverseMap();
            CreateMap<EnderecoViewModel, RequestEndereco>().ReverseMap();
        }
    }
}
