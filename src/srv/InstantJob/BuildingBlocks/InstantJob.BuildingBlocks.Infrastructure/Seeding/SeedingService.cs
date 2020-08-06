using System;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InstantJob.BuildingBlocks.Infrastructure.Seeding
{
    public class SeedingService : IHostedService
    {
        private readonly IServiceProvider provider;

        public SeedingService(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //IHostedServices do not have a scope created for them
            using var scope = provider.CreateScope();

            var seeders = scope.ServiceProvider.GetServices<IDataSeeder>();

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
