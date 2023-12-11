using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace BuberDinner.API.Filters;


public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<ErrorHandlingFilterAttribute> _logger;

    public ErrorHandlingFilterAttribute(ILogger<ErrorHandlingFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        if (exception is null)
        {
            return;
        }

        _logger.LogError($"Something went wrong: {context.Exception}");

        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred, while processing your request.",
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = context.Exception.Message
        };

        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}