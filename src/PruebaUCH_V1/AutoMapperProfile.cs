using AutoMapper;
using PruebaUCH_V1.Models.DTOs;
using PruebaUCH_V1.Models;

namespace PruebaUCH_V1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Definir mapeos
            CreateMap<Properties, PropertyListDTO>();
            CreateMap<Properties, PropertyDetailsDTO>();
            CreateMap<PropertyCreateDTO, Properties>();
            CreateMap<PropertyUpdateDTO, Properties>();
        }
    }
}
