using DAL.Entities;
using WebAPI.DTO;

namespace WebAPI.Mapping
{
    public static class ExcursionMappingExtensions
    {
        public static void ProjectFrom(this Excursion excursion, ChangeExcursionDTO changeProductDto)
        {
            excursion.Time = changeProductDto.Time;
            excursion.IsReserved = changeProductDto.IsReserved;
        }
    }
}
