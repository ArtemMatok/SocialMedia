using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monix.Application.DTOs.AppUserDTOs;
using Monix.Application.Extensions;
using Monix.Application.Interfaces;

namespace Monix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(
        IAuthenticationService _authService
    ) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);

            return result.ToResponse();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);

            return result.ToResponse();
        }
    }
}
