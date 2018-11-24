using AuctionSystem.Contracts.Models;

namespace AuctionSystem.Contracts.Services
{
    public interface ILoginService
    {
        TokenSet Login(string email, string password);
        bool ValidateToken(string accessToken);
    }
}