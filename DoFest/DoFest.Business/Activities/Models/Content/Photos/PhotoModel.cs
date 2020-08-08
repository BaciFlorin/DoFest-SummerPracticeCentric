using System;

namespace DoFest.Business.Activities.Models.Content.Photos
{
    public sealed class PhotoModel
    {
        public Guid Id { get; private set; }

        public Guid ActivityId { get; private set; }

        public Guid UserId { get; private set; }

        public string Username { get; private set; }

        public byte[] Image { get; private set; }

        public static PhotoModel Create(Guid id, Guid activityId, Guid userId, string username, byte[] image)
        {
            return new PhotoModel
            {
                Id = id,
                ActivityId = activityId,
                UserId = userId,
                Username = username,
                Image = image
            };
        }

    }
}
