namespace DotNetCenter.Beyond.Web.Core.FilterAttributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using DotNetCenter.Core.ExceptionHandlers;

    public sealed class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = context.Exception.Message
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                context.Exception = null;
            }
        }
    }
}
