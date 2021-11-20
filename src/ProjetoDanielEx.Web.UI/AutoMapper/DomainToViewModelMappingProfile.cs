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
            CreateMap<ClienteDTO, ClienteViewModel>();
            CreateMap<RequestAdicionarCliente, ClienteViewModel>();
        }
    }
}
