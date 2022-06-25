
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZucoBiH.Models
{
    public class Liked
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Cookie { get; set; }
        
    }
}
