using AutoMapper;
using DoFest.Business.Models.Activity;
using DoFest.Business.Models.BucketList;
using DoFest.Business.Models.Content.Photos;
using DoFest.Business.Models.Content.Ratings;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Lists;

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

            CreateMap<Activity, ActivityModel>();
            CreateMap<BucketList,BucketListModel>();
        }
    }
}
