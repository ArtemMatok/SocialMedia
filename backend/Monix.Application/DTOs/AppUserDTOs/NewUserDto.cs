using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Application.DTOs.AppUserDTOs
{
    public record NewUserDto(
        string? Email,
        string? UserName,
        string? Token
    );
}
