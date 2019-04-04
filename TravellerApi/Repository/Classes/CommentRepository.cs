using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(TravellerDbContext travellerContext) : base(travellerContext)
        {
        }

        public void CreateComment(Comment comment)
        {
            comment.CommentId = Guid.NewGuid();
            Create(comment);
            Save();
        }

        public void DeleteComment(Comment comment)
        {
            Delete(comment);
            Save();
        }


        public Comment GetComment(Guid commentId)
        {
            return Find(comment => comment.CommentId.Equals(commentId)).FirstOrDefault();
        }
    }
}
