using AutoMapper;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Entities.Activities.Content;

namespace DoFest.Business.Activities
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
