using AutoMapper;
using ProjetoDanielEx.Web.UI.Application.DTO;
using ProjetoDanielEx.Web.UI.Application.Request.Cliente;
using ProjetoDanielEx.Web.UI.ViewModel;

namespace ProjetoDanielEx.Web.UI.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            // Cliente
            CreateMap<ClienteDTO, ClienteViewModel>();
            CreateMap<RequestAdicionarCliente, ClienteViewModel>();
            CreateMap<RequestAtualizarCliente, ClienteViewModel>();

            // Endereco
            CreateMap<EnderecoDTO, EnderecoViewModel>().ReverseMap();
            CreateMap<RequestEndereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
