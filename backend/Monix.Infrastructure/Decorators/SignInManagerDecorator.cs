using Microsoft.AspNetCore.Identity;
using Monix.Application.Decorators;
using Monix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monix.Infrastructure.Decorators
{
    public class SignInManagerDecorator<T> : ISignInManagerDecorator<T> where T : AppUser
    {
        private readonly SignInManager<T> _signInManager;

        public SignInManagerDecorator(SignInManager<T> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> CheckPasswordSignInAsync(T user, string password, bool lockoutOnFailure)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
        }
    }
}
