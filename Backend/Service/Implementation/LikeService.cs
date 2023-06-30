using Infrastructure.Repositories;
using Model;
using Model.DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class LikeService : ILikeService
    {
        private readonly LikeRepository _likeRepository;
        private readonly IAuthService _authService;
        private readonly IPostService _postService;

        public LikeService(LikeRepository likeRepository, IAuthService authService, IPostService postService)
        { 
            _likeRepository = likeRepository;
            _authService = authService;
            _postService = postService;
        }

        public async Task<Like> NewLike(LikeDTO like)
        {
            var post = await _postService.GetPost(like.postId);

            if (post == null) throw new ArgumentException("Post doesn't exists.");

            var currentUser = await _authService.GetCurrentUser();
            var findLike = await _likeRepository.GetLikeByUserIdAndPostId(currentUser.Id, post.id);

            if (findLike != null) throw new ArgumentException("You already liked this post.");

            var newLike = new Like
            {
                postId = like.postId,
                userId = currentUser.Id
        };

            return await _likeRepository.CreateAsync(newLike);
        }
        public async Task<bool> RemoveLike(int postId)
        {
            var currentUser = await _authService.GetCurrentUser();
            var findLike = await _likeRepository.GetLikeByUserIdAndPostId(currentUser.Id, postId);
            if (findLike == null) throw new ArgumentException("Like not found.");

            return await _likeRepository.DeleteAsync(findLike);
        }

        public async Task<List<Like>> ListLikes()
        {
            var currentUser = await _authService.GetCurrentUser();
            var likes = await _likeRepository.ListLikesByUserId(currentUser.Id);
            return likes;
        }

        public async Task<List<Like>> ListLikesBypostId(int postId)
        {
            var post = await _postService.GetPost(postId);

            if (post == null) throw new ArgumentException("Post doesn't exists.");

            return await _likeRepository.ListLikesBypostId(postId);
        }
    }
}
