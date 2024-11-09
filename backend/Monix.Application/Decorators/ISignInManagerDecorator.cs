using Microsoft.AspNetCore.Identity;
using Monix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Application.Decorators
{
    public interface ISignInManagerDecorator<T> where T : AppUser
    {
        Task<SignInResult> CheckPasswordSignInAsync(T user, string password, bool lockoutOnFailure);
    }
}
