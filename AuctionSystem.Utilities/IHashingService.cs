namespace AuctionSystem.Utilities
{
    public interface IHashingService
    {
        string CreateHash(string plainTextPassword);
        bool Verify(string plainTextPassword, string hashedPassword);
    }
}