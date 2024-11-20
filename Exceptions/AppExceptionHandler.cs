using Azure;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using PasswordHashing.Models;

namespace PasswordHashing.Exceptions
{
    public class AppExceptionHandler:IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();

            if (exception is UserNotFoundException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = exception.Message;
                response.Title = "Invalid Login Attempt";
            }
            else if (exception is ValidationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = exception.Message;
                response.Title = "Validation Error";
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Message = "An unexpected error occurred.";
                response.Title = "Server Error";
            }

            httpContext.Response.StatusCode = response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
