using Microsoft.AspNetCore.Identity;
using Monix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Application.Decorators
{
    public interface IUserManagerDecorator<T> where T : AppUser
    {
        Task<T> FindByNameAsync(string email);
        Task<IdentityResult> CreateAsync(T user, string password);
        Task<IdentityResult> AddToRoleAsync(T user, string userRole);
        Task<IList<string>?> GetUserRoles(T user);
    }
}
