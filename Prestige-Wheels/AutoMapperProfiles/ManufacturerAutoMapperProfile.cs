using AutoMapper;
using Prestige_Wheels.Data.Entities;
using Prestige_Wheels.Models.Manufacturers;

namespace Prestige_Wheels.AutoMapperProfiles
{
    public class ManufacturerAutoMapperProfile : Profile
    {
        public ManufacturerAutoMapperProfile()
        {
            CreateMap<Manufacturer, ManufacturersViewModel>().ReverseMap();
        }
    }
}
