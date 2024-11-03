using AutoMapper;
using Businness.DTOs.AppUserDtos;
using Businness.Interfaces;
using Businness.Services;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services
{
    public class UserServiceTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        public UserServiceTest()
        {
            _userRepository = A.Fake<IUserRepository>();
            _mapper = A.Fake<IMapper>();
            _userService = new UserService(_userRepository, _mapper);
        }

        [Fact]
        public async Task UserService_GetUserByUserName_ReturnUserFullDto()
        {
            //Arrange
            var userName = "Test";
            var fakeUser = new AppUser() { UserName = userName };
            var fakeUserFullDto = new UserFullDto() { UserName = userName };

            A.CallTo(() => _userRepository.GetUserByUserName(userName)).Returns(Task.FromResult<AppUser?>(fakeUser));
            A.CallTo(() => _mapper.Map<UserFullDto?>(fakeUser)).Returns(fakeUserFullDto);


            //Act
            var result = await _userService.GetUserByUserName(userName);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<UserFullDto>();
        }




    }
}
