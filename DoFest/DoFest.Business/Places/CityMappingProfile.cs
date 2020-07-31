using AutoMapper;
using DoFest.Business.Places.Models;
using DoFest.Entities.Activities.Places;

namespace DoFest.Business.Places
{
    public class CityMappingProfile:Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CityModel>();
        }
    }
}