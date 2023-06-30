using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Request
    {
        public int id { get; set; }
        public string fromUsername { get; set; }
        public string toUsername { get; set; }
        public DateTime date { get; set; }  
        public bool accepted { get; set; }
    }
}
