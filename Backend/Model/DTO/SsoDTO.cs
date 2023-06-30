namespace Model.DTO
{
    public class SsoDTO
    {
        public string access_token { get; set; }
        public DateTime Expiration { get; set; }
        public User user { get; set; }

        //construtor
        public SsoDTO(string acess_token, DateTime expiration, User user)
        {
            this.access_token = acess_token;
            Expiration = expiration;
            this.user = user;
        }

    }
}
