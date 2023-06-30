using Infrastructure.Repositories;
using Model;
using Model.DTO;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class RequestService : IRequestService
    {
        private readonly RequestRepository _requestRepository;
        private readonly IAuthService _authService;
        private readonly IFriendService _friendService;

        public RequestService(RequestRepository requestRepository, IAuthService authService, IFriendService friendService)
        { 
            _requestRepository = requestRepository;
            _authService = authService;
            _friendService = friendService;
        }

        public async Task<Request> SendRequest(RequestDTO requestDTO)
        {
             return await CreateRequest(requestDTO.username);
        }

        public async Task<Request> CreateRequest(string toUsername)
        {
            var fromUser = await _authService.GetCurrentUser();

            var toUser = await _authService.GetUserByUserName(toUsername);

            if (toUser == null)
                throw new ArgumentException($"{toUsername} doesn't exists.");

            if (toUser.Id == fromUser.Id)
                throw new ArgumentException("You can't send a request to yourself.");

            var alreadyFriend = await _friendService.GetFriendUsingIds(fromUser.Id, toUser.Id);

            if (alreadyFriend != null)
                throw new ArgumentException($"You already have {toUser.UserName} in your friend list");

            var newRequest = new Request
            {
                fromUsername = fromUser.UserName,
                toUsername = toUser.UserName,
                date = DateTime.Now,
                accepted = false
        };

            return await _requestRepository.CreateAsync(newRequest);
        }

        public async Task<bool> RefuseRequest(int requestId)
        {
            var request = await _requestRepository.GetByIdAsync(requestId);

            if (request == null)
                throw new ArgumentException("Request doesn't exists.");

            return await _requestRepository.DeleteAsync(request);
        }

        public async Task<bool> AcceptRequest(int requestId)
        {
            var request = await _requestRepository.GetByIdAsync(requestId);

            if (request == null)
                throw new ArgumentException("Request doesn't exists.");

            request.accepted = true;
            await _friendService.AddFriend(request.fromUsername);

            return await _requestRepository.InsertOrUpdateAsync(request) == 1;
        }


        public async Task<List<Request>> ListPendentRequests()
        {
            var currentUser = await _authService.GetCurrentUser();
            var requests = await _requestRepository.ListPendentRequestsByUserId(currentUser.UserName);

            return requests;
        }
    }
}
