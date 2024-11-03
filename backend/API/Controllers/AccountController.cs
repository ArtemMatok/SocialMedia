using Businness.DTOs.AppUserDtos;
using Businness.Interfaces;
using Data.Helpers;
using Data.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signingManager;
        private readonly IUserService _userService;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signingManager, IUserService userService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signingManager = signingManager;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto, IValidator<RegisterDto> validator)
        {
            try
            {

                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    Name = registerDto.Name,
                };
                var initials = ImageGenerator.GetInitials(appUser.Name);
                string randomColor = ImageGenerator.GenerateRandomColor();
                appUser.Image = $"https://ui-avatars.com/api/?name={initials}&size=200&background={randomColor}&color=000000";

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(new NewUserDto()
                        {
                          
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto, [FromServices] IValidator<LoginDto> validator)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if (user is null)
            {
                return Unauthorized("Invalid user name");
            }

            var result = await _signingManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("User name not found and/or password incorrect");
            }

            return Ok(
                new NewUserDto
                {
                  
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }

        [HttpGet("GetUserByUserName/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            if (userName is null)
            {
                return BadRequest("User name is required");
            }

            var user = await _userService.GetUserByUserName(userName);

            if(user is null)
            {
                return NotFound("User wasn`t found");
            }

            return Ok(user);
        }
    }
}
