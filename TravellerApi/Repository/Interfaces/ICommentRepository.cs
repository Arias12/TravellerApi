﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void CreateComment(Comment comment);
        void DeleteComment(Comment comment);
        Comment GetComment(Guid commentId);
    }
}
