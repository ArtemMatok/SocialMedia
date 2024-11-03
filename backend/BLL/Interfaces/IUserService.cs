using Businness.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Interfaces
{
    public interface IUserService 
    {
        Task<UserFullDto?> GetUserByUserName(string userName);  
    }
}
