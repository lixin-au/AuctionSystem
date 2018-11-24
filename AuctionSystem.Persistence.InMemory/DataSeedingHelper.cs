using AuctionSystem.Contracts.Models;
using Common.Utilities;
using System;
using System.Collections.Generic;

namespace AuctionSystem.Persistence.InMemory
{
    public static class DataSeedingHelper
    {
        public static (ICollection<AppUser> AppUsers, ICollection<AuctionItem> AuctionItems) GetSeeds()
        {
            var hashingService = new HashingService();

            var seller1 = new AppUser
            {
                Key = Guid.NewGuid(),
                CanSell = true,
                Email = "seller1@someemail.com",
                HashedPassword = hashingService.CreateHash("123")
            };

            var seller2 = new AppUser
            {
                Key = Guid.NewGuid(),
                CanSell = true,
                Email = "seller2@someemail.com",
                HashedPassword = hashingService.CreateHash("234")
            };

            (ICollection<AppUser> AppUsers, ICollection<AuctionItem> AuctionItems) seeds =
                (AppUsers: null, AuctionItems: null);

            seeds.AppUsers = new List<AppUser>
            {
                seller1,
                seller2,
                new AppUser
                {
                    Key = Guid.NewGuid(),
                    Email = "buyer1@someemail.com",
                    HashedPassword = hashingService.CreateHash("345")
                },
                new AppUser
                {
                    Key = Guid.NewGuid(),
                    Email = "buyer2@someemail.com",
                    HashedPassword = hashingService.CreateHash("456")
                },
                new AppUser
                {
                    Key = Guid.NewGuid(),
                    Email = "buyer3@someemail.com",
                    HashedPassword = hashingService.CreateHash("567")
                },
            };

            seeds.AuctionItems = new List<AuctionItem>
            {
                new AuctionItem
                {
                    Key = Guid.NewGuid(),
                    Description = "Description of Item1",
                    Increment = 1M,
                    Name = "Item1",
                    ReservePrice = 10M,
                    Seller = seller1,
                    TimeClosed = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(10)),
                    TimeStarted = DateTimeOffset.UtcNow
                },
                new AuctionItem
                {
                    Key = Guid.NewGuid(),
                    Description = "Description of Item2",
                    Increment = 0.1M,
                    Name = "Item2",
                    ReservePrice = 1.6M,
                    Seller = seller2,
                    TimeClosed = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(10)),
                    TimeStarted = DateTimeOffset.UtcNow
                }
            };

            return seeds;
        }
    }
}