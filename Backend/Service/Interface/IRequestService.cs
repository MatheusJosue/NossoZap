using Model;
using Model.DTO;

namespace Service.Interface
{
    public interface IRequestService
    {
        Task<Request> CreateRequest(string toUsername);
        Task<Request> SendRequest(RequestDTO requestDTO);
        Task<bool> AcceptRequest(int requestId);
        Task<bool> RefuseRequest(int requestId);
        Task<List<Request>> ListPendentRequests();
    }
}
