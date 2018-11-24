using AuctionSystem.Contracts.Models;

namespace AuctionSystem.Contracts.Persistence
{
    public interface IRepository
    {
        AppUser GetAppUserByEmail(string email);
    }
}