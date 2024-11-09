using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Application.DTOs.AppUserDTOs
{
    public record RegisterDto(
        string? Name,
        string? UserName,
        string? Email,
        string? Password
    );
}
