using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Service.Interface;

namespace Application.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("create-comment")]
        public async Task<IActionResult> NewComment([FromBody] CommentDTO comment)
        {
            try
            {
                return Ok(await _commentService.NewComment(comment));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("remove-comment")]
        public async Task<IActionResult> RemoveComment([FromQuery] int commentId)
        {
            try
            {
                return Ok(await _commentService.RemoveComment(commentId));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("list-comments")]
        public async Task<IActionResult> ListComments()
        {
            try
            {
                return Ok(await _commentService.ListComments());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
