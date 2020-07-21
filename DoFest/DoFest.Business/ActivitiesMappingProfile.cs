using AutoMapper;
using DoFest.Business.Models.Photos;
using DoFest.Business.Models.Ratings;
using DoFest.Entities.Activities.Content;

namespace DoFest.Business
{
     public class ActivitiesMappingProfile:Profile
    {
        public ActivitiesMappingProfile()
        {
            CreateMap<CreatePhotoModel, Photo>();
            CreateMap<Photo, PhotoModel>();

            CreateMap<CreateRatingModel, Rating>();
            CreateMap<Rating, RatingModel>();
        }
    }
}
