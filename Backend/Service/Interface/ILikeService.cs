using Model;
using Model.DTO;

namespace Service.Interface
{
    public interface ILikeService
    {
        Task<Like> NewLike(LikeDTO like);
        Task<bool> RemoveLike(int likeId);
        Task<List<Like>> ListLikes();
        Task<List<Like>> ListLikesBypostId(int publicationId);
    }
}
