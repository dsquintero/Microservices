using AutoMapper;
using PersonasMicroservice.Application.DTOs;
using PersonasMicroservice.Domain.Entities;

namespace PersonasMicroservice.Application.Mappings
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<Persona, PersonaDTO>()
                .ForMember(dest => dest.TipoPersona, opt => opt.MapFrom(src => src.TipoPersona != null ? src.TipoPersona.Desc : string.Empty))
                .ReverseMap();

        }
    }
}