using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<User, Guid>
    {
        private readonly MySQLContext _context;
        public UserRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _context.User.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        }
        public async Task<User> GetUser(string userId)
        {
            User user = await _context.User.FindAsync(userId);

            return user;
        }
    }
}
