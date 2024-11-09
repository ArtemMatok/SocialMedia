using Microsoft.AspNetCore.Mvc;
using Monix.Application.Models;
using Monix.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Application.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToResponse<T>(this Result<T> result)
        {
            var response = new ApiResponse<T>(result);

            if (result.IsSuccess)
            {
                return new OkObjectResult(response.Data);
            }
            else
            {
                return new BadRequestObjectResult(response);
            }
        }

    }
}
