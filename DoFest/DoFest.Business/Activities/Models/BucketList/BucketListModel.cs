using System;

namespace DoFest.Business.Activities.Models.BucketList
{
    public sealed class BucketListModel
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Username { get; private set; }

        public static BucketListModel Create(Guid id, string name, string username)
        {
            return new BucketListModel
            {
                Id = id,
                Name = name,
                Username = username
            };
        }
    }
}
