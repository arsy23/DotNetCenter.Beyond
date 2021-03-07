namespace DotNetCenter.Beyond.Web.Core.Middlewares
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using System.Text.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using DotNetCenter.Core.ExceptionHandlers;
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
            => _next = next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Unhandled exception ...", ex);
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //This code below just copy and not any refactored
            //app.UseExceptionHandler(config =>
            //{
            //    config.Run(async context =>
            //    {
            //        context.Response.StatusCode = 500;
            //        context.Response.ContentType = "application/json";

            //        var error = context.Features.Get<IExceptionHandlerFeature>();
            //        if (error != null)
            //        {
            //            var ex = error.Error;

            //            await context.Response.WriteAsync(new ErrObjRelMappingodel()
            //            {
            //                StatusCode = 500,
            //                ErrObjRelMappingessage = ex.Message
            //            }.ToString()); //ToString() is overridden to Serialize object
            //        }
            //    });
            //});
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case FluentValidation.ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case EntityNotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
                result = JsonSerializer.Serialize(new { error = exception.Message });

            return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) => builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
