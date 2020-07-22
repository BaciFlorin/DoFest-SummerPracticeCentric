using AutoMapper;
using DoFest.Business.Models.Content.Comment;
using DoFest.Entities.Activities.Content;

namespace DoFest.Business
{
    /// <summary>
    /// Profil de mapping intre modelele si entitati de comentarii.
    /// </summary>
    public class CommentMappingProfile: Profile
    {
        public CommentMappingProfile()
        {
            // ****** Mappere pentru modele de comentarii ******
            CreateMap<NewCommentModel, Comment>();
            CreateMap<Comment, CommentModel>();
        }
    }
}
