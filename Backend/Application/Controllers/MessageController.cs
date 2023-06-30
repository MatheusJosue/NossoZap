using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Service.Interface;

namespace Application.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("create-message")]
        public async Task<IActionResult> CreateMessage([FromBody] MessageDTO message)
        {
            try
            {
                return Ok(await _messageService.CreateMessage(message));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("remove-message")]
        public async Task<IActionResult> RemoveMessage([FromBody] int id)
        {
            try
            {
                return Ok(await _messageService.RemoveMessage(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("get-message")]
        public async Task<IActionResult> GetMessage([FromQuery] int id)
        {
            try
            {
                return Ok(await _messageService.GetMessage(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("list-messages-with-user")]
        public async Task<IActionResult> ListMessagesWithUser([FromQuery] string username)
        {
            try
            {
                return Ok(await _messageService.ListMessagesWithUser(username));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("list-last-messages")]
        public async Task<IActionResult> ListLastMessages()
        {
            try
            {
                return Ok(await _messageService.ListLastMessages());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
