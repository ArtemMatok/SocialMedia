using Monix.Application.Decorators;
using Monix.Application.DTOs.AppUserDTOs;
using Monix.Application.Helpers;
using Monix.Application.Interfaces;
using Monix.Application.Models;
using Monix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Application.Services
{
    public class AuthenticationService(
           IUserManagerDecorator<AppUser> _userManager,
           ITokenService _tokenService,
           ISignInManagerDecorator<AppUser> _signInManager
       ) : IAuthenticationService
    {
        public async Task<Result<NewUserDto>> Login(LoginDto loginDto)
        {

            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user is null)
            {
                return Result<NewUserDto>.Failure("User wasn`t found");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Result<NewUserDto>.Failure("Email not found and/or password incorrect");
            }

            var roles = await _userManager.GetUserRoles(user);
            var userRole = roles.FirstOrDefault();

            if (string.IsNullOrEmpty(userRole))
            {
                return Result<NewUserDto>.Failure("Role assignment failed. No role found for the user.");
            }

            var newUserDto = new NewUserDto(
                user.UserName,
                user.Email,
                await _tokenService.CreateToken(user)
            );

            return Result<NewUserDto>.Success(newUserDto);
        }

        public async Task<Result<NewUserDto>> Register(RegisterDto registerDto)
        {
            var existingUser = await _userManager.FindByNameAsync(registerDto.UserName);
            if (existingUser != null)
            {
                return Result<NewUserDto>.Failure("Email is already in use");
            }

            var appUser = new AppUser
            {
                Name = registerDto.UserName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };
            var initials = ImageGenerator.GetInitials(appUser.Name);
            string randomColor = ImageGenerator.GenerateRandomColor();
            appUser.Image = $"https://ui-avatars.com/api/?name={initials}&size=200&background={randomColor}&color=000000";

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (!createdUser.Succeeded)
            {
                var errorsUser = createdUser.Errors.Select(x => x.Description).ToList();
                return Result<NewUserDto>.Failure(errorsUser);
            }

            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
            if (!roleResult.Succeeded)
            {
                var errorsRole = roleResult.Errors.Select(x => x.Description).ToList();
                return Result<NewUserDto>.Failure(errorsRole);
            }

            var roles = await _userManager.GetUserRoles(appUser);
            var userRole = roles.FirstOrDefault();

            if (string.IsNullOrEmpty(userRole))
            {
                return Result<NewUserDto>.Failure("Role assignment failed. No role found for the user.");
            }

            var newUser = new NewUserDto(
                appUser.UserName,
                appUser.Email,
                await _tokenService.CreateToken(appUser)
            );

            return Result<NewUserDto>.Success(newUser);
        }
    }
}
