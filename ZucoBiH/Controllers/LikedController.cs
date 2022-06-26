using Microsoft.AspNetCore.Mvc;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZucoBiH.Controllers
{
    [ApiController]
    public class LikedController : ControllerBase
    {
        private readonly Context _context;

        public LikedController(Context context)
        {
            _context = context;
        }

        // GET api/<ValuesController>/5
        [HttpGet("getlikes/{postId}")]
        public int Get(int postId)
        {
            return _context.Likes.Where(x => x.PostId == postId).Count();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("like/{postId}")]
        public ActionResult<UserHash> LikePost(int postId, UserHash kuki)
        {
            if (kuki.Value is null)
            {
                LikePostWithId(postId);
                var newValue = Guid.NewGuid().ToString();

                _context.Likes.Add(new Models.Liked() { PostId = postId, Cookie = newValue });
                _context.SaveChangesAsync();
                return new UserHash() { Value = newValue };
            }
            else
            {
                var hasLiked = _context.Likes.Where(l => l.PostId == postId && l.Cookie == kuki.Value).Any();

                if (!hasLiked)
                {
                    LikePostWithId(postId);
                    _context.Likes.Add(new Models.Liked() { PostId = postId, Cookie = kuki.Value });
                    _context.SaveChangesAsync();
                    return kuki;
                }
            }

            return BadRequest();
        }

        private async void LikePostWithId(int postId)
        {
            var post = _context.Posts.Where(p => p.Id == postId).FirstOrDefault();

            if (post is not null)
            {
                post.Upvote += 1;
                _context.Update(post);
            }
        }
    }

    public class UserHash
    {
        public string? Value { get; set; }
    }
}
