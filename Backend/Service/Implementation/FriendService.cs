using Infrastructure.Data.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Model;
using Model.DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class FriendService : IFriendService
    {
        private readonly IAuthService _authService;
        private readonly FriendRepository _friendRepository;
        private readonly UserRepository _userRepository;

        public FriendService(FriendRepository friendRepository, IAuthService authService, UserRepository userRepository)
        {
            _friendRepository = friendRepository;
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<Friend> GetFriendUsingIds(string fromUserId,  string toUserId)
        {
            return await _friendRepository.GetFriendUsingIds(fromUserId, toUserId);
        }

        public async Task<bool> AddFriend(string toUsername)
        {
            User currentUser = await _authService.GetCurrentUser();
            User friendUser = await _userRepository.GetUserByUserName(toUsername);

            if (friendUser == null)
                throw new ArgumentException($"User {toUsername} doesn't exists.");

            if (currentUser.Id == friendUser.Id)
                throw new ArgumentException("You can't add yourself");

            var alreadyFriend = await GetFriendUsingIds(currentUser.Id, friendUser.Id);

            if (alreadyFriend != null)
                throw new ArgumentException($"You already have {toUsername} in your friends list.");

            var friend = new Friend
            {
                addedAt = DateTime.Now,
                friendId = friendUser.Id,
                userId = currentUser.Id,
                friendName = friendUser.UserName,
                username = currentUser.UserName
            };

            return await _friendRepository.CreateAsync(friend) != null;
        }

        public async Task<Boolean> RemoveFriend(RemoveFriendDTO friendDTO)
        {
            var username = friendDTO.Username;
            if (username == null) throw new ArgumentNullException($"Invalid username: {username}.");

            User currentUser = await _authService.GetCurrentUser();
            User friendUser = await _userRepository.GetUserByUserName(username);

            if (friendUser == null)
                throw new ArgumentException($"User {username} doesn't exists.");

            Friend friend = await _friendRepository.GetFriendUsingIds(currentUser.Id, friendUser.Id);

            if(friend == null)
                throw new ArgumentException($"{username} is not your friend.");

            return await _friendRepository.DeleteAsync(friend);
        }

        public async Task<List<FriendDTO>> ListFriends()
        {
            User currentUser = await _authService.GetCurrentUser();

            List<Friend> sendFriends = await _friendRepository.ListSendFriendsByUserId(currentUser.Id);
            List<FriendDTO> friendsDTO = new List<FriendDTO>();

            foreach (var friend in sendFriends)
            {
                var dto = new FriendDTO
                {
                    id = friend.friendId,
                    username = friend.friendName,
                    addedAt = friend.addedAt
                };
                friendsDTO.Add(dto);
            }

            List<Friend> receivedFriends = await _friendRepository.ListReceivedFriendsByUserId(currentUser.Id);

            foreach (var friend in receivedFriends)
            {
                var dto = new FriendDTO
                {
                    id = friend.userId,
                    username = friend.username,
                    addedAt = friend.addedAt
                };
                friendsDTO.Add(dto);
            }

            return friendsDTO;
        }
    }
}
