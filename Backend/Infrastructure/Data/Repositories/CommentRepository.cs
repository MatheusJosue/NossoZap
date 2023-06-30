using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Infrastructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment, int>
    {
        public readonly MySQLContext _context;
        public CommentRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Comment>> ListCommentsByUserId(string userId)
        {
            return await _context.Comment.Where(x => x.userId.Equals(userId)).ToListAsync();
        }

        public async Task<List<Comment>> ListCommentsByPostId(int postId)
        {
            return await _context.Comment.Where(x => x.postId.Equals(postId)).ToListAsync();
        }

        public async Task<List<Comment>> GetCommentByUserIdAndPostId(string userId, int postId)
        {
            return await _context.Comment.Where(x => x.postId.Equals(postId) && x.userId.Equals(userId)).ToListAsync();
        }
    }
}
