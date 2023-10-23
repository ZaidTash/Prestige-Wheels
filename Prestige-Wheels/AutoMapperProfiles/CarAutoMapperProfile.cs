using AutoMapper;
using Prestige_Wheels.Data.Entities;
using Prestige_Wheels.Models.Cars;

namespace Prestige_Wheels.AutoMapperProfiles
{
    public class CarAutoMapperProfile : Profile
    {
        public CarAutoMapperProfile()
        {
            CreateMap<Car,CarViewModel>().ReverseMap();
        }
    }
}
