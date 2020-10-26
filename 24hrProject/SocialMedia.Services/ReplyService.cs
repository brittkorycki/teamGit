using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Models;

namespace SocialMedia.Services
{
    public class ReplyService
    {
            private readonly int _ReplyId = -1;
            public ReplyService()
            {
            }
            public bool CreateReply(ReplyCreate model)
            {
                var entity =
                    new Reply()
                    {
                        ReplyComment = model.ReplyComment,
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Reply.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }

            public IEnumerable<ReplyList> GetReply()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Reply
                            .Where(e => e.ReplyId == _ReplyId)
                            .Select(
                                e =>
                                    new ReplyList
                                    {
                                        ReplyId = e.ReplyId,
                                        Text = e.Text,
                                    }
                            );

                    return query.ToArray();
                }

            }

            public ReplyDetail GetReplyById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Reply
                            .Single(e => e.ReplyId == id);
                    return
                        new ReplyDetail
                        {
                            CommentId = entity.CommentID,
                            Text = entity.Text,
                            Author = entity.Author,
                        };
                }
            }
            //update by ID
            public bool UpdateReply(ReplyEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Reply
                            .Single(e => e.ReplyId == _ReplyId);

                entity.Text = model.Text;
                    entity.Author = model.Author;

                    return ctx.SaveChanges() == 1;

                }
            }

            public bool DeleteReply(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Reply
                            .Single(e => e.ReplyId == id);

                ctx.Reply.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }

