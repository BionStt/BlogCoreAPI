using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogCoreAPI.Data;
using BlogCoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogCoreAPI.Controllers
{
    [Route("bca/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        protected BlogContext blogContext;

        public PostsController(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        // GET bca/posts
        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            return this.blogContext.Posts.Include(c => c.Comments).ToList();
        }

        // GET bca/posts/5
        [HttpGet("{postId}")]
        public ActionResult<Post> Get(int postId)
        {
            return this.blogContext.Posts.Include(c => c.Comments).FirstOrDefault(p => p.PostId == postId);
        }

        // POST bca/posts
        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.blogContext.Posts.Add(post);
            this.blogContext.SaveChanges();

            return Ok();
        }

        // PUT bca/posts/5
        [HttpPut("{postId}")]
        public IActionResult Put(int postId, [FromBody] Post post)
        {
            if (!blogContext.Posts.Any())
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.blogContext.Posts.Update(post);
            this.blogContext.SaveChanges();

            return Ok();
        }

        // DELETE bca/posts/5
        [HttpDelete("{postId}")]
        public IActionResult Delete(int postId)
        {
            var post = this.blogContext.Posts.Include(c => c.Comments).FirstOrDefault(p => p.PostId == postId);

            if (post == null)
            {
                return NotFound();
            }

            this.blogContext.Comments.RemoveRange(post.Comments);
            this.blogContext.Posts.Remove(post);
            this.blogContext.SaveChanges();

            return NoContent();
        }
    }
}
