﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZucoBiH.Controllers
{
    [ApiController]
    public class LikedController : ControllerBase
    {
        private readonly Context _context;

        // GET api/<ValuesController>/5
        [HttpGet("getlikes/{id}")]
        public int Get(int postId)
        {
            return _context.Likes.Where(x => x.PostId == postId).Count();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("like/{id}")]
        public void LikePost(int postId)
        {
            string kuki = null;
            Request.Cookies.TryGetValue("id", out kuki);

            if (kuki is null)
            {
                LikePostWithId(postId);

                var response = Request.Cookies.Append(new KeyValuePair<string, string>("id", Guid.NewGuid().ToString()));
            }
            else
            {
                var hasLiked = _context.Likes.Where(l => l.PostId == postId && l.Cookie == kuki).Any();

                if (!hasLiked)
                {
                    LikePostWithId(postId);
                }
            }
        }

        private async void LikePostWithId(int postId)
        {
            var post = _context.Posts.Where(p => p.Id == postId).FirstOrDefault();

            if (post is not null)
            {
                post.Upvote += 1;
                _context.Update(post);
                _context.SaveChangesAsync();
            }
        }
    }
}
