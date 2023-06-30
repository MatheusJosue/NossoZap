using Model.DTO;
using Model.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAccountService
    {
        Task<SsoDTO> SignIn(LoginModel signInDTO);
        Task<bool> SignUp(RegisterModel signUpDTO);
    }
}
