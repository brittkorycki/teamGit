using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24hrProject.Controllers
{
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userID = User.Identity.GetUserId();
            var LikeService = new LikeService(userID);
            return CommentService;
        }
    }
    public IHttpActionResult Post(LikeCreate Like)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var service = CreateLikeService();
        if (!service.CreateLike(Like))
            return InternalServerError();
        return Ok();
    }
}
