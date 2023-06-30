using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public int postId { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
    }
}
