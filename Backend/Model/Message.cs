using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Message
    {
        [Key]
        public int Id { get; set; } 
        public string fromUsername { get; set; }
        public string toUsername { get; set; } 
        public string fromUserId { get; set; }
        public string toUserId { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
    }
}
