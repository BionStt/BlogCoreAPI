using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogCoreAPI.Data;
using BlogCoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogCoreAPI.Controllers
{
    [Route("bca/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        protected BlogContext blogContext;

        public CommentsController(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        // GET bca/comments
        [HttpGet("{postId}")]
        public ActionResult<IEnumerable<Comment>> Get(int postId)
        {
            return this.blogContext.Comments.Where(c => c.PostId == postId).ToList();
        }

        // POST bca/comments/5
        [HttpPost("{postId}")]
        public IActionResult Post(int postId, [FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            comment.PostId = postId;

            this.blogContext.Comments.Add(comment);
            this.blogContext.SaveChanges();

            return Ok();
        }

        // PUT bca/comments/5
        [HttpPut("{commentId}")]
        public IActionResult Put(int commentId, [FromBody] Comment comment)
        {
            if (!blogContext.Comments.Any())
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.blogContext.Comments.Update(comment);
            this.blogContext.SaveChanges();

            return Ok();
        }

        // DELETE bca/comments/5
        [HttpDelete("{commentId}")]
        public IActionResult Delete(int commentId)
        {
            var comment = this.blogContext.Comments.FirstOrDefault(c => c.CommentId == commentId);

            if (comment == null)
            {
                return NotFound();
            }

            this.blogContext.Comments.Remove(comment);
            this.blogContext.SaveChanges();

            return NoContent();
        }
    }
}
