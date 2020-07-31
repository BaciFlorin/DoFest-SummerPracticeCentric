using AutoMapper;
using DoFest.Business.Activities.Models.Places;
using DoFest.Entities.Activities.Places;

namespace DoFest.Business.Activities
{
    public class CityMappingProfile:Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CityModel>();
        }
    }
}