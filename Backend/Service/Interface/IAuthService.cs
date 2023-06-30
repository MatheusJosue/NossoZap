using Microsoft.AspNetCore.Identity;
using Model;
using Model.DTO;
using Model.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAuthService
    {
        Task<User> GetCurrentUser();
        Task<User> GetUserById(string userId);
        Task<User> GetUserByUserName(string username);
    }
}
