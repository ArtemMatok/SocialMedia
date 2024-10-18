using Businness.DTOs.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Validation.AppUserValid
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(login => login.UserName)
                .NotEmpty().WithMessage("User name is required")
                .MinimumLength(2);

            RuleFor(login => login.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password`s length must be more than 8 symbols")
                .Matches(@"[A-Za-z]").WithMessage("Password must contain at least one letter")
                .Matches(@"[@#$]").WithMessage("Password must contain at least one special character (@, #, $)");
        }
    }
}
