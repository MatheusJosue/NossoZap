using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.DTO;
using Model.JWT;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> SignUp(RegisterModel signUpDTO)
        {
            var userExists = await _userManager.FindByNameAsync(signUpDTO.Username);
            if (userExists != null)
                throw new ArgumentException("Username already exists!");

            userExists = await _userManager.FindByEmailAsync(signUpDTO.Email);
            if (userExists != null)
                throw new ArgumentException("Email already exists!");

            User user;

            user = new User()
            {
                Email = signUpDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = signUpDTO.Username,
                telephoneNumber = signUpDTO.TelephoneNumber
            };

            var result = await _userManager.CreateAsync(user, signUpDTO.Password);

            if (!result.Succeeded)
                throw new ArgumentException("Cadastro do usuário falhou.");

            user = await _userManager.FindByNameAsync(signUpDTO.Username);

            return true;
        }

        public async Task<SsoDTO> SignIn(LoginModel signInDTO)
        {
            var user = await _userManager.FindByNameAsync(signInDTO.Username);
            if (user == null)
                throw new ArgumentException("Usuário não encontrado.");

            if (!await _userManager.CheckPasswordAsync(user, signInDTO.Password))
                throw new ArgumentException("Senha inválida.");

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new SsoDTO(new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo, user);
        }
    }
}
