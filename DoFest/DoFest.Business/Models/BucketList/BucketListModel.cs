using System;
using System.Collections.Generic;
using System.Text;

namespace DoFest.Business.Models.BucketList
{
    public sealed class BucketListModel
    {
        public Guid UserId { get; private set; }

        public string Name { get; private set; }

        public string Username { get; private set; }

    }

}
