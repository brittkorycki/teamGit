using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SocialMedia.Services;
using SocialMedia.Models;

namespace _24hrProject.Controllers
{
     [Authorize]
        public class ReplyController : ApiController
        {

            //creates Comment service
            private ReplyService CreateReplyService()
            {
                var ReplyService = new ReplyService();
                return ReplyService;
            }

            //gets all Comments
            public IHttpActionResult GetReply()
            {
                ReplyService ReplyService = CreateReplyService();
                var Reply = ReplyService.GetReply();
                return Ok(Reply);
            }
            //create comment
            public IHttpActionResult PostReply(ReplyCreate Reply)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var service = CreateReplyService();
                if (!service.CreateReply(Reply))
                    return InternalServerError();
                return Ok();
            }

            //get by ID
            public IHttpActionResult Get(int id)
            {
                ReplyService ReplyService = CreateReplyService();
                var Reply = ReplyService.GetReplyById(id);
                return Ok(Reply);
            }
            //update by ID
            public IHttpActionResult UpdateReply(ReplyEdit Reply)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateReplyService();

                if (!service.UpdateReply(Reply))
                    return InternalServerError();

                return Ok();
            }
            //delete 
            public IHttpActionResult DeleteReply(int id)
            {
                var service = CreateReplyService();

                if (!service.DeleteReply(id))
                    return InternalServerError();

                return Ok();
            }

        }
    }