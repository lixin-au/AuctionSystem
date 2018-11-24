using System.Threading;
using System.Threading.Tasks;
using AuctionSystem.Contracts.Persistence;
using Microsoft.Extensions.Hosting;

namespace AuctionSystem.Persistence.InMemory
{
    public class Repository : IRepository, IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}