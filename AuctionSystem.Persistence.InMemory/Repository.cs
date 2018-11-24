using AuctionSystem.Contracts.Models;
using AuctionSystem.Contracts.Persistence;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionSystem.Persistence.InMemory
{
    public class Repository : IRepository, IHostedService
    {
        protected readonly ConcurrentBag<AppUser> AppUsers;
        protected readonly ConcurrentBag<AuctionItem> AuctionItems;
        protected readonly ConcurrentBag<Bid> Bids = new ConcurrentBag<Bid>();

        public Repository()
        {
            var (appUsers, auctionItems) = DataSeedingHelper.GetSeeds();
            AppUsers = new ConcurrentBag<AppUser>(appUsers);
            AuctionItems = new ConcurrentBag<AuctionItem>(auctionItems);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public AppUser GetAppUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            email = email.Trim();

            var appUser = AppUsers.FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return appUser;
        }
    }
}