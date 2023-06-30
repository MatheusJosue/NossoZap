using Model;
using Model.DTO;

namespace Service.Interface
{
    public interface ICommentService
    {
        Task<Comment> NewComment(CommentDTO comment);
        Task<bool> RemoveComment(int commentId);
        Task<List<Comment>> ListComments();
        Task<List<Comment>> ListCommentsByPostId(int postId);
    }
}
