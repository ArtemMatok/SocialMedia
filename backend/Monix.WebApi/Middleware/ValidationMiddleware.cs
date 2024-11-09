using FluentValidation;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Text.Json;

namespace Monix.WebApi.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ValidationMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var actionDescriptor = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();

            if (actionDescriptor != null)
            {
                context.Request.EnableBuffering();

                foreach (var parameter in actionDescriptor.Parameters)
                {
                    if (context.Request.ContentLength > 0)
                    {
                        using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
                        var body = await reader.ReadToEndAsync();

                        context.Request.Body.Position = 0;

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        var argument = JsonSerializer.Deserialize(body, parameter.ParameterType, options);

                        var validatorType = typeof(IValidator<>).MakeGenericType(parameter.ParameterType);
                        var validator = context.RequestServices.GetService(validatorType) as IValidator;

                        if (validator != null && argument != null)
                        {
                            var result = await validator.ValidateAsync(new ValidationContext<object>(argument));

                            if (!result.IsValid)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                await context.Response.WriteAsJsonAsync(result.Errors);
                                return;
                            }
                        }
                    }
                }
            }

            await _requestDelegate(context);
        }
    }
}
