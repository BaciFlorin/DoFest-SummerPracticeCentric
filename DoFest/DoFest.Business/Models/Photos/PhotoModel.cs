using System;
using System.Collections.Generic;
using System.Text;

namespace DoFest.Business.Models.Photos
{
    public sealed class PhotoModel
    {
        public Guid Id { get; private set; }

        public Guid ActivityId { get; private set; }

        public Guid UserId { get; private set; }

        public byte[] Image { get; private set; }

    }
}
