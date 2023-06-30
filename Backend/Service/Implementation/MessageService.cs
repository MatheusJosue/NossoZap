using Infrastructure.Repositories;
using Model;
using Model.DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly MessageRepository _messageRepository;
        private readonly IAuthService _authService;

        public MessageService(MessageRepository messageRepository, IAuthService authService)
        { 
            _messageRepository = messageRepository;
            _authService = authService;
        }

        public async Task<Message> CreateMessage(MessageDTO message)
        {
            var currentUser = await _authService.GetCurrentUser();

            var toUser = await _authService.GetUserByUserName(message.toUsername);

            if (toUser == null)
                throw new ArgumentException($"{message.toUsername} doesn't exists.");

            if (toUser.Id == currentUser.Id)
                throw new ArgumentException("You can't send a message to yourself.");

            var newMessage = new Message
            {
                date = DateTime.Now,
                fromUserId = currentUser.Id,
                toUserId = toUser.Id,
                text = message.text,
                fromUsername = currentUser.UserName,
                toUsername = toUser.UserName
        };

            return await _messageRepository.CreateAsync(newMessage);
        }

        public async Task<bool> RemoveMessage(int messageId)
        {
            var message = await _messageRepository.GetByIdAsync(messageId);

            if (message == null)
                throw new ArgumentException("Message doesn't exists.");

            return await _messageRepository.DeleteAsync(message);
        }

        public async Task<Message> GetMessage(int messageId)
        {
            var message = await _messageRepository.GetByIdAsync(messageId);

            var currentUser = await _authService.GetCurrentUser();

            if (message.fromUserId != currentUser.Id)
                throw new ArgumentException("You can't see this message.");

            if (message == null)
                throw new ArgumentException("Message doesn't exists.");

            return message;
        }

        public async Task<List<Message>> ListMessagesWithUser(string username)
        {
            var currentUser = await _authService.GetCurrentUser();
            var toUser = await _authService.GetUserByUserName(username);

            if (toUser == null)
                throw new ArgumentException($"{username} doesn't exists.");

            if(toUser.Id == currentUser.Id)
                throw new ArgumentException("You can't send a message to yourself.");

            var messages = await _messageRepository.ListMessagesWithUser(currentUser.Id, toUser.Id);

            return messages;
        }

        public async Task<List<LastReceivedMessageDTO>> ListLastMessages()
        {
            var currentUser = await _authService.GetCurrentUser();
            var messages = await _messageRepository.ListUserMessages(currentUser.Id);
            var lastMessages = new List<LastReceivedMessageDTO>();
            var alreadyLast = new List<string>();
            
            foreach(Message message in messages)
            {
                if(message.fromUserId == currentUser.Id)
                {
                    if (FindUserIdInLastMessages(alreadyLast, message.toUserId))
                        continue;
                    alreadyLast.Add(message.toUserId);
                } else
                {
                    if (FindUserIdInLastMessages(alreadyLast, message.fromUserId))
                        continue;
                    alreadyLast.Add(message.fromUserId);
                }
            }

            foreach(string userId in alreadyLast)
            {
                var lastMessage = await _messageRepository.GetLastMessageWithUser(userId, currentUser.Id);
                var lastMessageDTO = new LastReceivedMessageDTO();

                lastMessageDTO.lastMessage = lastMessage.text;
                lastMessageDTO.date = lastMessage.date;
                lastMessageDTO.username = lastMessage.fromUserId == currentUser.Id ? lastMessage.toUsername : lastMessage.fromUsername;
                lastMessageDTO.userId = lastMessage.fromUserId == currentUser.Id ? lastMessage.toUserId : lastMessage.fromUserId;
                lastMessages.Add(lastMessageDTO);
            }

            return lastMessages;
        }

        public bool FindUserIdInLastMessages(List<string> messages, string userId) => messages.Find(x => x.Equals(userId)) != null;
    }
}
