using Monix.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Application.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse(Result<T> result)
        {
            Success = result.IsSuccess;
            Data = result.IsSuccess ? result.Value : default;
            ErrorMessage = result.ErrorMessage;
            Errors = result.Errors;
        }
    }
}
