using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Infrastructure.Repositories
{
    public class FriendRepository : GenericRepository<Friend, int>
    {
        public readonly MySQLContext _context;
        public FriendRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Friend> GetFriendUsingIds(string userId, string friendId) 
        {
            return await _context.Friend.Where(x => x.userId.Equals(userId) && x.friendId.Equals(friendId) || x.userId.Equals(friendId) && x.friendId.Equals(userId)).FirstOrDefaultAsync();
        }

        public async Task<List<Friend>> ListFriendsByUserId(string userId)
        {
            return await _context.Friend.Where(x => (x.userId.Equals(userId)) || x.friendId.Equals(userId)).ToListAsync();
        }

        public async Task<List<Friend>> ListSendFriendsByUserId(string userId)
        {
            return await _context.Friend.Where(x => (x.userId.Equals(userId))).ToListAsync();
        }

        public async Task<List<Friend>> ListReceivedFriendsByUserId(string userId)
        {
            return await _context.Friend.Where(x => (x.friendId.Equals(userId))).ToListAsync();
        }
    }
}
