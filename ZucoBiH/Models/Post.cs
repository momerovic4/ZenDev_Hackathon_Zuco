
namespace ZucoBiH.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public double Logngitude { get; set; }
        public double Latitude { get; set; }
        public string Category { get; set; }
        public string Image64 { get; set; }
        public bool Done { get; set; }
        public bool Positive { get; set; }
    }
}
