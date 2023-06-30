using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Model.JWT;
using Service.Interface;

namespace Application.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("create-post")]
        public async Task<IActionResult> CreatePost([FromBody] PostDTO post)
        {
            try
            {
                return Ok(await _postService.CreatePost(post));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("update-post")]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDTO post)
        {
            try
            {
                return Ok(await _postService.UpdatePost(post));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        [HttpDelete("remove-post")]
        public async Task<IActionResult> RemovePost([FromQuery] int postId)
        {
            try
            {
                return Ok(await _postService.RemovePost(postId));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("get-post")]
        public async Task<IActionResult> GetPost([FromQuery] int id)
        {
            try
            {
                return Ok(await _postService.GetPost(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("list-posts")]
        public async Task<IActionResult> ListPosts()
        {
            try
            {
                return Ok(await _postService.ListPosts());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
