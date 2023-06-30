using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Like
    {
        [Key]
        public int id { get; set; }
        public int postId { get; set; }
        public string userId { get; set; }
    }
}
