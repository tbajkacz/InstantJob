using InstantJob.Core.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace InstantJob.Api.Middleware
{
    public class UnitOfWorkFinalizerFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork uow;

        public UnitOfWorkFinalizerFilter(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!uow.Active)
            {
                throw new Exception("Unit of work connection is already closed");
            }

            var executedContext = await next.Invoke();

            if (executedContext.Exception == null)
            {
                await uow.CommitAsync();
            }
            else
            {
                await uow.RollbackAsync();
            }
        }
    }

    public static class UnitOfWorkFinalizerFilterExtensions
    {
        public static IMvcBuilder AddUnitOfWorkFinalizerFilter(this IMvcBuilder builder)
        {
            return builder.AddMvcOptions(o => o.Filters.Add<UnitOfWorkFinalizerFilter>());
        }
    }
}
