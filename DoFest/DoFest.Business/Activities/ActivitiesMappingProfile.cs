using AutoMapper;
using DoFest.Business.Activities.Models.Content.Comment;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Entities.Activities.Content;

namespace DoFest.Business.Activities
{
    /// <summary>
    /// Profil de mapping intre modelele si entitati.
    /// </summary>
    public class ActivitiesMappingProfile:Profile
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
        }
    }
}
