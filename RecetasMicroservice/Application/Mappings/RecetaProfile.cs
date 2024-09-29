using AutoMapper;
using RecetasMicroservice.Api.DTOs;
using RecetasMicroservice.Domain.Entities;

namespace RecetasMicroservice.Application.Mappings
{
    public class RecetaProfile : Profile
    {
        public RecetaProfile()
        {
            CreateMap<Receta, RecetaDTO>()
                .ForMember(dest => dest.TipoPersona, opt => opt.MapFrom(src => src.TipoPersona != null ? src.TipoPersona.Desc : string.Empty))
                .ReverseMap();

        }
    }
}