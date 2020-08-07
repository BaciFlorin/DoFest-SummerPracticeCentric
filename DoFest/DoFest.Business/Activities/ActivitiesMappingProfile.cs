using AutoMapper;
using DoFest.Business.Activities.Models.Activity;
using DoFest.Business.Activities.Models.Activity.ActivityType;
using DoFest.Business.Activities.Models.BucketList;
using DoFest.Business.Activities.Models.Content.Comment;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Authentication;
using DoFest.Entities.Lists;

namespace DoFest.Business.Activities
{
    /// <summary>
    /// Profil de mapping intre modelele si entitati.
    /// </summary>
    public class ActivitiesMappingProfile : Profile
    {
        public ActivitiesMappingProfile()
        {
            CreateMap<CreatePhotoModel, Photo>();
            CreateMap<Photo, PhotoModel>();

            CreateMap<CreateRatingModel, Rating>();
            CreateMap<Rating, RatingModel>();

            // ****** Mappere pentru modele de comentarii ******
            CreateMap<NewCommentModel, Comment>();
            CreateMap<CommentModel, Comment>();
            CreateMap<Comment, CommentModel>();

            CreateMap<Activity, ActivityModel>();
            CreateMap<CreateActivityModel, Activity>();
            CreateMap<BucketList, BucketListModel>();

            CreateMap<User, BucketListModel>();

            CreateMap<ActivityType, ActivityTypeModel>();
            CreateMap<CreateActivityTypeModel, ActivityType>();
        }
    }
}
