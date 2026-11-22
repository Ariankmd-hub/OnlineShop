using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace OnlineShop.WebApi.Exceptions;

public sealed class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }
        //if (exception is not ValidationException validationException)
        //{
        //    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        //    await httpContext.Response.WriteAsJsonAsync(
        //        new
        //        {
        //            title = exception.Message,
        //            detail = exception.InnerException?.Message
        //        },
        //        cancellationToken);

        //    return true;
        //}


        var errors = validationException.Errors
            .GroupBy(error => error.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => group.Select(error => error.ErrorMessage).ToArray());

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(
            new
            {
                title = "One or more validation errors occurred.",
                errors
            },
            cancellationToken);

        return true;
    }
}
