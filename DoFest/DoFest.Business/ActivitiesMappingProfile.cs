using AutoMapper;
using DoFest.Business.Models.Content.Comment;
using DoFest.Business.Models.Content.Photos;
using DoFest.Business.Models.Content.Ratings;
using DoFest.Entities.Activities.Content;

namespace DoFest.Business
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
            CreateMap<Comment, CommentModel>();
        }
    }
}
