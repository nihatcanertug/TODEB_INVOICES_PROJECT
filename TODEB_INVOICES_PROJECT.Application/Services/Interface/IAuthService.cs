using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Application.Auth;
using TODEB_INVOICES_PROJECT.Application.Auth.Response;

namespace TODEB_INVOICES_PROJECT.Application.Services.Interface
{
    public interface IAuthService
    {
        CommandResponse VerifyPassword(string email, string password);
        AccessToken Login(string email, string password);
    }
}
