using AuctionSystem.Contracts.Persistence;
using AuctionSystem.Contracts.Services;

namespace AuctionSystem.Services
{
    public class AuctionService : IAuctionService
    {
        protected readonly IRepository Repository;


        public AuctionService(IRepository repository)
        {
            Repository = repository;
        }
    }
}