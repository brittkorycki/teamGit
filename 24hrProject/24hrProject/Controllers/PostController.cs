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
    [RoutePrefix ("api/post")]
    public class PostController : ApiController
    {
        //creates Post service
        private PostService CreatePostService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var PostService = new PostService(userID);
            return PostService;
        }
        //gets all Posts
        public IHttpActionResult GetPosts()
        {
            PostService PostService = CreatePostService();
            var Posts = PostService.GetPost();
            return Ok(Posts);
        }
        //create post
        public IHttpActionResult Post(CreatePost Post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePostService();
            if (!service.CreatePost(Post))
                return InternalServerError();
            return Ok();
        }

        //get by ID
        public IHttpActionResult Get(int id)
        {
            PostService PostService = CreatePostService();
            var Post = PostService.GetPostById(id);
            return Ok(Post);
        }
        //update by ID
        public IHttpActionResult Put(PostEdit Post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(Post))
                return InternalServerError();

            return Ok();
        }
        //delete 
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }
    }
}
