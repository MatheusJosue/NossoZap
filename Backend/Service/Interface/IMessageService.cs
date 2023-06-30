using Model;
using Model.DTO;

namespace Service.Interface
{
    public interface IMessageService
    {
        Task<Message> CreateMessage(MessageDTO message);
        Task<Message> GetMessage(int messageId);
        Task<bool> RemoveMessage(int messageId);
        Task<List<Message>> ListMessagesWithUser(string username);
        Task<List<LastReceivedMessageDTO>> ListLastMessages();
    }
}
