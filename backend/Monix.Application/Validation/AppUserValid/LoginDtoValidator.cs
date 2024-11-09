using FluentValidation;
using Monix.Application.DTOs.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Application.Validation.AppUserValid
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(login => login.UserName)
                .NotEmpty().WithMessage("Email is required")
                .MinimumLength(2).WithMessage("Minimum 2 symbols");

            RuleFor(login => login.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 8 characters long ")
                .Matches(@"[A-Za-z]").WithMessage("Password must contain at least one letter")
                .Matches(@"[@#$]").WithMessage("Password must contain at least one special character (@, #, $)");
        }
    }
}
