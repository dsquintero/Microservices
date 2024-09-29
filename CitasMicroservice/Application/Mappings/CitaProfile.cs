using AutoMapper;
using CitasMicroservice.Api.DTOs;
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