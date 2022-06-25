
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZucoBiH.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Category { get; set; }
        [DefaultValue(null)]
        public string? Image64 { get; set; } = null;
        [DefaultValue(null)]
        public string? VideoUrl { get; set; } = null;
        public bool IsVideo { get; set; } = false;
        [DefaultValue(false)]
        public bool Approved { get; set; } = false;
        public bool Positive { get; set; }
        [DefaultValue(0)]
        public int Upvote { get; set; } = 0;
    }
}
