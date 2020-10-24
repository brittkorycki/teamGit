using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SocialMedia.Services
{
    public class CommentService
    //Controller- all methods needed for comments
    {
        private readonly int _commentId = -1;
        public CommentService()
        { 
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    CommentID = _commentId,
                    Text = model.Text,
                    Author = model.Author,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentList> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comment
                        .Where(e => e.CommentID == _commentId)
                        .Select(
                            e =>
                                new CommentList
                                {
                                    CommentId = e.CommentID,
                                    Text = e.Text,
                                }
                        );

                return query.ToArray();
            }

        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentID == id && e.CommentID == _commentId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentID,
                        Text = entity.Text,
                        Author = entity.Author,
                    };
            }
        }
        //update by ID
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentID == model.CommentId && e.CommentID == _commentId);

                entity.Text = model.Text;
                entity.Author = model.Author;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteComment(int CommentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentID == CommentId && e.CommentID == _commentId);

                ctx.Comment.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

