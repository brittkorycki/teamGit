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
            var CommentService = new CommentService();
            return CommentService;
        }

        //gets all Comments
        public IHttpActionResult GetPostComments()
        {
                CommentService CommentService = CreateCommentService();
                var Comments = CommentService.GetComment();
                return Ok(Comments);
        }
            //create comment
        public IHttpActionResult PostComment(CommentCreate Comment)
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
         public IHttpActionResult UpdateComment(CommentEdit Comment)
         {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateCommentService();

                if (!service.UpdateComment(Comment))
                    return InternalServerError();

                return Ok();
         }
            //delete 
         public IHttpActionResult DeleteComment(int id)
         {
                var service = CreateCommentService();

                if (!service.DeleteComment(id))
                    return InternalServerError();

                return Ok();
         }
        
    }
}

