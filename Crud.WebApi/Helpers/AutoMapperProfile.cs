using AutoMapper;
using Crud.Domain;
using Crud.WebApi.Dto;

namespace Crud.WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
        
    }
}