﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoFest.Entities.Activities.Content;

namespace DoFest.Persistence.Comments
{
    public interface ICommentsRepository: IRepository<Comment>
    {
        Task<List<Comment>> GetComments(Guid activityId);

        void AddComment(Comment comment);

        void DeleteComment(Guid commentId);
    }
}
