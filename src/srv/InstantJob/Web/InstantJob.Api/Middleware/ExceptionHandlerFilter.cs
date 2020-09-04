using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace InstantJob.Web.Api.Middleware
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
                    response = JsonConvert.SerializeObject(validationException.Failures);
                    break;
                case EntityAccessException _:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                case EntityNotFoundException _:
                    statusCode = HttpStatusCode.NotFound;
                    break;
            }
            context.Result = new ObjectResult(response)
            {
                StatusCode = (int)statusCode,
            };
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
