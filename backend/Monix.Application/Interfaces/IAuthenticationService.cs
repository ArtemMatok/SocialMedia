using Monix.Application.DTOs.AppUserDTOs;
using Monix.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Result<NewUserDto>> Register(RegisterDto registerDto);
        Task<Result<NewUserDto>> Login(LoginDto loginDto);
    }
}
