using AutoMapper;
using DoFest.Business.Activities.Models.Activity;
using DoFest.Business.Activities.Models.BucketList;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Authentication;
using DoFest.Entities.Lists;

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

            CreateMap<Activity, ActivityModel>();
            CreateMap<BucketList,BucketListModel>();

            CreateMap<User, BucketListModel>();


        }
    }
}
