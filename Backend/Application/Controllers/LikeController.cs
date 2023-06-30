using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Service.Interface;

namespace Application.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("create-like")]
        public async Task<IActionResult> NewLike([FromBody] LikeDTO like)
        {
            try
            {
                return Ok(await _likeService.NewLike(like));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("remove-like")]
        public async Task<IActionResult> RemoveLike([FromQuery] int postId)
        {
            try
            {
                return Ok(await _likeService.RemoveLike(postId));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("list-likes")]
        public async Task<IActionResult> ListLikes()
        {
            try
            {
                return Ok(await _likeService.ListLikes());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("list-likes-by-post-id")]
        public async Task<IActionResult> LikesLikesByPostId(int postId)
        {
            try
            {
                return Ok(await _likeService.ListLikesBypostId(postId));
            } catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
