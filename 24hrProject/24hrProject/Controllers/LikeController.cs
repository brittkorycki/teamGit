using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace _24hrProject.Controllers
{
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var LikeService = new LikeService();
            return LikeService;
        }
    }
    public IHttpActionResult PostLike(LikeCreate Like)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var service = CreateLikeService();
        if (!service.CreateLike(Like))
            return InternalServerError();
        return Ok();
    }
}
