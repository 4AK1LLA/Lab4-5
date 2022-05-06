using AutoMapper;
using DAL.Entities;
using WebAPI.DTO;

namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Exhibition mappings
            CreateMap<ExhibitionDTO, Exhibition>();
            CreateMap<Exhibition, ExhibitionDTO>();

            // Excursion mappings
            CreateMap<Excursion, ExcursionDTO>();
            CreateMap<ExcursionDTO, Excursion>();
        }
    }
}
