using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class FriendDTO
    {
        public string id { get; set; }
        public string username { get; set; }
        public DateTime addedAt { get; set; }
    }

    public class AddFriendDTO
    {
        public string Username { get; set; }
    }

    public class RemoveFriendDTO
    {
        public string Username { get; set; }

    }
}
