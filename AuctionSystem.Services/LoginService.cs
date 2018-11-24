using AuctionSystem.Contracts.Models;
using AuctionSystem.Contracts.Persistence;
using AuctionSystem.Contracts.Services;
using Common.Utilities;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionSystem.Services
{
    public class LoginService : ILoginService, IHostedService
    {
        protected readonly IRepository Repository;
        protected readonly IHashingService HashingService;

        protected readonly ConcurrentDictionary<Guid, TokenSet> AppUserTokenSets =
            new ConcurrentDictionary<Guid, TokenSet>();

        public LoginService(IRepository repository, IHashingService hashingService)
        {
            Repository = repository;
            HashingService = hashingService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public TokenSet Login(string email, string password)
        {
            var appUser = Repository.GetAppUserByEmail(email);
            if (appUser == null || !HashingService.Verify(password, appUser.HashedPassword))
                return null;

            var tokenSet = new TokenSet();
            AppUserTokenSets.AddOrUpdate(appUser.Key, tokenSet, (key, existingTokenSet) => tokenSet);

            return tokenSet;
        }

        public bool ValidateToken(string accessToken)
        {
            var tokenSet = AppUserTokenSets.Values.FirstOrDefault(x => x.AccessToken == accessToken);
            var isValid = !(tokenSet is null) && !tokenSet.IsExpired;
            return isValid;
        }
    }
}