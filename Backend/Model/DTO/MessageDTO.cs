using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class MessageDTO
    {
        public string toUsername { get; set; }
        public string text { get; set; }
    }
}
