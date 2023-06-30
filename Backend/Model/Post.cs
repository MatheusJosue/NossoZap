using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public string message { get; set; }
        public Byte[]? photo { get; set; }
        public List<Like> likes { get; set; }   
        public DateTime date { get; set; }
        public List<Comment> comments { get; set; }
    }
}
