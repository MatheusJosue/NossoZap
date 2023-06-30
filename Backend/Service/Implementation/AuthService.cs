using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.DTO;
using Model.JWT;
using Service.Interface;

namespace Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public AuthService(UserRepository userRepository, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<User> GetCurrentUser()
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User); // Get user id:

            User user = await _userRepository.GetUser(userId);


            return user;
        }

        public async Task<User> GetUserById(string userId)
        {
            User user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new ArgumentException("Usuario não encontrado");
            }

            return user;
        }

        public async Task<User> GetUserByUserName(string username)
        {
            User user = await _userRepository.GetUserByUserName(username);
            if (user == null)
                throw new ArgumentException("Usuário não encontrado");

            return user;
        }
    }
}
