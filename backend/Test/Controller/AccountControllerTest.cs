using API.Controllers;
using Businness.DTOs.AppUserDtos;
using Businness.Interfaces;
using Businness.Services;
using Data.Models;
using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Controller
{
    public class AccountControllerTest
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IValidator<RegisterDto> _validatorRegister;
        private readonly IValidator<LoginDto> _validatorLogin;
        private readonly IUserService _userService;
        public AccountControllerTest()
        {
            _userManager = A.Fake<UserManager<AppUser>>();
            _tokenService = A.Fake<ITokenService>();
            _signInManager = A.Fake<SignInManager<AppUser>>();  
            _validatorRegister = A.Fake<IValidator<RegisterDto>>();
            _validatorLogin = A.Fake<IValidator<LoginDto>>();
            _userService = A.Fake<IUserService>();   
        }

        [Fact]
        public async void AccountController_Register_ReturnOk()
        {
            //Arrange
            var registerDto = new RegisterDto()
            {
                Email = "test@gmail.com",
                Name = "Test",
                UserName = "Test",
                Password = "Testtest1@",
            };
            FluentValidation.Results.ValidationResult validResult = new FluentValidation.Results.ValidationResult();
           

            A.CallTo(() => _validatorRegister.ValidateAsync(registerDto,default)).Returns(Task.FromResult(validResult));
            A.CallTo(() => _userManager.CreateAsync(A<AppUser>.Ignored, A<string>.Ignored)).Returns(Task.FromResult(IdentityResult.Success));
            A.CallTo(() => _userManager.AddToRoleAsync(A<AppUser>.Ignored, A<string>.Ignored)).Returns(Task.FromResult(IdentityResult.Success));
            var controller = new AccountController(_userManager,_tokenService,_signInManager, _userService);

            //Act
            var result = await controller.Register(registerDto, _validatorRegister); ;


            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task AccountController_GetUserByUserName_ReturnOk()
        {
            //Arrange
            var userName = "Test";
            var fakeUser = A.Fake<UserFullDto>(); 
            fakeUser.UserName = userName;

            A.CallTo(() => _userService.GetUserByUserName(userName))
                .Returns(Task.FromResult<UserFullDto?>(fakeUser));
            var controller = new AccountController(_userManager, _tokenService, _signInManager, _userService);
            //Act
            var result = await controller.GetUserByUserName(userName);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
