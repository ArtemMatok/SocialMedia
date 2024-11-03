using AutoMapper;
using Businness.DTOs.AppUserDtos;
using Businness.Interfaces;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserFullDto?> GetUserByUserName(string userName)
        {
            var user = await _userRepository.GetUserByUserName(userName);

            return _mapper.Map<UserFullDto?>(user);
        }
    }
}
