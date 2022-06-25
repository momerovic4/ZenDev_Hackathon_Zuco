using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZucoBiH.Models;

namespace ZucoBiH.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly Context _context;
        public PostController(Context context)
        {
            _context = context;
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostModel(int id)
        {
            var postModel = await _context.Posts.FindAsync(id);

            if (postModel == null)
            {
                return NotFound();
            }

            return postModel;
        }
        // GET: api/Posts/5
        [HttpGet("notapproved")]
        public async Task<ActionResult<List<Post>>> GetPostModel()
        {
            var postModel = await _context.Posts.Where(x => x.Approved == false).ToListAsync();

            if (postModel == null)
            {
                return NotFound();
            }

            return postModel;
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> PutPostModel(int id, Post postModel)
        {
            if (id != postModel.Id)
            {
                return BadRequest();
            }

            postModel.Approved = true;

            _context.Update(postModel);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("posts")]
        public IEnumerable<Post> GetPostModel([FromQuery] QueryParameters parameters)
        {
            var page = parameters.page;
            var size = parameters.size;

            if (page == 0)
                page = 1;

            if (size == 0)
                size = int.MaxValue;

            var skip = (page - 1) * size;

            return _context.Posts.Skip(skip).Take(size).AsEnumerable();
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostModel(int id)
        {
            var postModel = await _context.Posts.FindAsync(id);
            if (postModel == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(postModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Posts
        [HttpPost("post")]
        public async Task<ActionResult<Post>> PostModel(Post postModel)
        {
            _context.Posts.Add(postModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostModel), new { id = postModel.Id }, postModel);
        }
        [HttpGet("pages")]
        public int GetPagesModel([FromQuery] QueryParameters parameters)
        {
            double count = _context.Posts.Count();
            var size = parameters.size;//po stranici itema

            if (size == 0)
                size = 6;

            int pages = (int)Math.Ceiling(count / size);

            return pages;
        }
    }

    public class QueryParameters
    {
        public int size { get; set; }
        public int page { get; set; }
    }
}
