using InstantJob.Core.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace InstantJob.Api.Middleware
{
    public class ExceptionHandlerFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var response = context.Exception.Message;

            switch (context.Exception)
            {
                case ValidationFailedException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    response = JsonSerializer.Serialize(validationException.Failures);
                    break;
                case EntityAccessException _:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                case EntityNotFoundException _:
                    statusCode = HttpStatusCode.NotFound;
                    break;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;
            await context.HttpContext.Response.WriteAsync(response);
        }
    }

    public static class ExceptionHandlerFilterExtentions
    {
        public static IMvcBuilder AddExceptionHandlerFilter(this IMvcBuilder builder)
        {
            return builder.AddMvcOptions(o => o.Filters.Add<ExceptionHandlerFilter>());
        }
    }
}
