using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAtribute : ExceptionFilterAttribute{

    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new {

            Title = "An error occured while processing your request.",
            Status = (int)HttpStatusCode.InternalServerError
        };

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
       
    }

}