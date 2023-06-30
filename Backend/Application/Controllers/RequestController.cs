using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Service.Interface;

namespace Application.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("accept-request")]
        public async Task<IActionResult> AcceptRequest([FromBody] int requestId)
        {
            try
            {
                return Ok(await _requestService.AcceptRequest(requestId));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("refuse-request")]
        public async Task<IActionResult> RefuseRequest([FromBody] int requestId)
        {
            try
            {
                return Ok(await _requestService.RefuseRequest(requestId));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("list-pendent-requests")]
        public async Task<IActionResult> ListPendentRequests()
        {
            try
            {
                return Ok(await _requestService.ListPendentRequests());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("send-friend-request")]
        public async Task<IActionResult> SendFriendRequest(RequestDTO requestDTO)
        {
            try
            {
                return Ok(await _requestService.SendRequest(requestDTO));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
