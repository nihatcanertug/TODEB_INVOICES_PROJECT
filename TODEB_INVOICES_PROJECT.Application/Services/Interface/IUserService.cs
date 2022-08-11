using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Application.Models.DTOs;

namespace TODEB_INVOICES_PROJECT.Application.Services.Interface
{
    public interface IUserService
    {
        Task DeleteUser(params object[] parameters);
        Task<IdentityResult> Register(RegisterDTO registerDTO);
        Task<SignInResult> LogIn(LoginDTO loginDTO);
        Task LogOut();
        Task<int> GetUserIdFromName(string name);
    }
}
