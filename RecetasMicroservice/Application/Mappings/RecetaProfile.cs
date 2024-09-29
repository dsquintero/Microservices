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
                .ForMember(dest => dest.Medicamentos, opt => opt.MapFrom(src => src.Medicamentos))
                .ReverseMap();

            CreateMap<Medicamento, MedicamentoDTO>()
                .ReverseMap();
        }
    }
}