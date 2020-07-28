using System;

namespace DoFest.Business.Activities.Models.BucketList
{
    public sealed class BucketListModel
    {
        public Guid UserId { get; private set; }

        public string Name { get; private set; }

        public string Username { get; private set; } //TODO: de vazut private set-ul

        public static BucketListModel Create(Guid userId, string name, string username)
        {
            return new BucketListModel
            {
                UserId = userId,
                Name = name,
                Username = username
            };
        }

    }

}
