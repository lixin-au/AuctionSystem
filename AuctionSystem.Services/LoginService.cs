using AuctionSystem.Contracts.Persistence;
using AuctionSystem.Contracts.Services;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionSystem.Services
{
    public class LoginService : ILoginService, IHostedService
    {
        protected readonly IRepository Repository;

        public LoginService(IRepository repository)
        {
            Repository = repository;
        }

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