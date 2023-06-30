using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTO;

namespace Infrastructure.Repositories
{
    public class PostRepository : GenericRepository<Post, int>
    {
        public readonly MySQLContext _context;
        public PostRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Post>> ListPostsByUserId(string userId)
        {
            return await _context.Post.Where(x => x.userId.Equals(userId)).ToListAsync();
        }

        public async Task<List<Post>> ListPostsByFriends(List<FriendDTO> friends, string userId)
        {
            var friendIds = friends.Select(x => x.id).ToList();
            return await _context.Post.Where(x => friendIds.Contains(x.userId) || x.userId.Equals(userId)).OrderByDescending(x => x.date).ToListAsync();
        }

        public async Task<List<Like>> ListLikesByPostId(int postId)
        {
            return await _context.Like.Where(x => x.postId == postId).ToListAsync();
        }

        public async Task<List<Comment>> LikesCommentsByPostId(int postId)
        {
            return await _context.Comment.Where(x => x.postId == postId).ToListAsync();
        }
    }
}
