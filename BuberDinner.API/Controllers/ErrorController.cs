using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        var (statusCode, message) = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (500, "An unexpected error occurred.")
        };

        return Problem(title: message, statusCode: statusCode);
    }
}