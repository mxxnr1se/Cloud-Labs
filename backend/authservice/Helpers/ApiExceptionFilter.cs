using BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using InvalidDataException = BLL.Exceptions.InvalidDataException;

namespace authservice.Helpers;

public class ApiExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        context.Result = context.Exception switch
        {
                InvalidDataException => new BadRequestObjectResult(context.Exception.Message),
                DbQueryResultNullException => new NotFoundObjectResult(context.Exception.Message),
                IdentityException => new NotFoundObjectResult(context.Exception.Message),
                _ => new BadRequestObjectResult(
                        "Unhandled error occured.") // {context.Exception}: {context.Exception.Message}")
        };

        base.OnException(context);
    }
}