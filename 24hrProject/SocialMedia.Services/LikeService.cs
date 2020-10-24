using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class LikeService

    {
        //public LikeService()
        //{
        //}
        public bool CreateUserLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    LikedUser = model.LikedUser,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Like.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //public bool DeleteLike(int LikeId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Like
        //                .Single(e => e.LikeID == LikeId && e.LikeID == _LikeId);

        //        ctx.Like.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
    }
}
