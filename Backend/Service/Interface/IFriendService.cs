using Model;
using Model.DTO;

namespace Service.Interface
{
    public interface IFriendService
    {
        Task<bool> AddFriend(string toUsername);
        Task<bool> RemoveFriend(RemoveFriendDTO username);
        Task<List<FriendDTO>> ListFriends();
        Task<Friend> GetFriendUsingIds(string fromUserId, string toUserId);
    }
}
