using Microsoft.AspNetCore.Identity;

namespace Model
{
    public class User : IdentityUser
    {
        public string telephoneNumber { get; set; }
        public List<Post> publications { get; set; }
        public List<Friend> friends { get; set; }
        public List<Like> likes { get; set; }
    }
}
