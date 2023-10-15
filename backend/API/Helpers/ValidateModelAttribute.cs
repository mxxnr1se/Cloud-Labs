using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid)
            return;

        string errorMessage = (from modelState in context.ModelState.Values
                               from error in modelState.Errors
                               select error.ErrorMessage).FirstOrDefault();

        context.Result = new BadRequestObjectResult(errorMessage);
    }
}