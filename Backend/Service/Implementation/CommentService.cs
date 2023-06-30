using Infrastructure.Repositories;
using Model;
using Model.DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepository _commentRepository;
        private readonly IAuthService _authService;
        private readonly IPostService _postService;

        public CommentService(CommentRepository commentRepository, IAuthService authService, IPostService postService)
        { 
            _commentRepository = commentRepository;
            _authService = authService;
            _postService = postService;
        }

        public async Task<Comment> NewComment(CommentDTO comment)
        {
            var post = await _postService.GetPost(comment.postId);

            if (post == null) throw new ArgumentException("Post doesn't exists.");

            var currentUser = await _authService.GetCurrentUser();

            var newComment = new Comment
            {
                postId = comment.postId,
                userId = currentUser.Id,
                date = DateTime.Now,
                message = comment.message,
                userName = currentUser.UserName
        };

            return await _commentRepository.CreateAsync(newComment);
        }
        public async Task<bool> RemoveComment(int commentId)
        {
            var currentUser = await _authService.GetCurrentUser();
            var findComment = await _commentRepository.GetByIdAsync(commentId);
            var getPost = await _postService.GetPost(findComment.postId);
            if (findComment == null) throw new ArgumentException("Comment not found.");
            if (findComment.userId != currentUser.Id && getPost.userId != currentUser.Id) throw new ArgumentException("You can't remove other comment.");

            return await _commentRepository.DeleteAsync(findComment);
        }

        public async Task<List<Comment>> ListComments()
        {
            var currentUser = await _authService.GetCurrentUser();
            var comments = await _commentRepository.ListCommentsByUserId(currentUser.Id);
            return comments;
        }

        public async Task<List<Comment>> ListCommentsByPostId(int postId)
        {
            var post = await _postService.GetPost(postId);

            if (post == null) throw new ArgumentException("Post doesn't exists.");

            return await _commentRepository.ListCommentsByPostId(postId);
        }
    }
}
