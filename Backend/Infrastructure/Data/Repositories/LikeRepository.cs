using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTO;

namespace Infrastructure.Repositories
{
    public class LikeRepository : GenericRepository<Like, int>
    {
        public readonly MySQLContext _context;
        public LikeRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Like>> ListLikesByUserId(string userId)
        {
            return await _context.Like.Where(x => x.userId.Equals(userId)).ToListAsync();
        }

        public async Task<List<Like>> ListLikesBypostId(int postId)
        {
            return await _context.Like.Where(x => x.postId.Equals(postId)).ToListAsync();
        }

        public async Task<Like?> GetLikeByUserIdAndPostId(string userId, int postId)
        {
            return await _context.Like.Where(x => x.postId.Equals(postId) && x.userId.Equals(userId)).FirstOrDefaultAsync();
        }
    }
}
