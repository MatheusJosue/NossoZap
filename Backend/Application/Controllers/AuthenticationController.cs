using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Model.JWT;
using Service.Interface;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAuthService _authService;
        public AuthenticationController(IAccountService accountService, IAuthService authService)
        {
            _accountService = accountService;
            _authService = authService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel model)
        {
            try
            {
                return Ok(await _accountService.SignUp(model));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] LoginModel model)
        {
            try
            {
                SsoDTO user = await _accountService.SignIn(model);
                return Ok(user);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("get-current-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                return Ok(await _authService.GetCurrentUser());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }

}
