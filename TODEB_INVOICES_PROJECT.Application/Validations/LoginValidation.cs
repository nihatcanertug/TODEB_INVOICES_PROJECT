using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Application.Models.DTOs;

namespace TODEB_INVOICES_PROJECT.Application.Validations
{
    public class LoginValidation : AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Enter a username");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Enter a password");
        }
    }
}
