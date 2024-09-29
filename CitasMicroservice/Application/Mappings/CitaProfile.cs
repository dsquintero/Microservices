using AutoMapper;
using CitasMicroservice.Application.DTOs;
using CitasMicroservice.Domain.Entities;

namespace CitasMicroservice.Application.Mappings
{
    public class CitaProfile : Profile
    {
        public CitaProfile()
        {
            CreateMap<Cita, CitaDTO>()
                .ReverseMap();

        }
    }
}