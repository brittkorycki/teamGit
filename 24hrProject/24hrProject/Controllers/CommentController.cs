using Microsoft.AspNet.Identity;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24hrProject.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {

        //creates Comment service
        private CommentService CreateCommentService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var PostService = new PostService(userID);
            return CommentService;
        }

        //gets all Comments
        public IHttpActionResult Get()
            {
                CommentService CommentService = CreateCommentService();
                var Comments = CommentService.GetComment();
                return Ok(Comments);
            }
            //create comment
            public IHttpActionResult Post(CommentCreate Post)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var service = CreateCommentService();
                if (!service.CreateComment(Comment))
                    return InternalServerError();
                return Ok();
            }

            //get by ID
            public IHttpActionResult Get(int id)
            {
                CommentService CommentService = CreateCommentService();
            var Comment = CommentService.GetCommentById(id);
                return Ok(Comment);
            }
            //update by ID
            public IHttpActionResult Put(CommentEdit Comment)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateCommentService();

                if (!service.UpdateComment(Comment))
                    return InternalServerError();

                return Ok();
            }
            //delete 
            public IHttpActionResult Delete(int id)
            {
                var service = CreateCommentService();

                if (!service.DeleteComment(id))
                    return InternalServerError();

                return Ok();
            }
        }
    }
}

