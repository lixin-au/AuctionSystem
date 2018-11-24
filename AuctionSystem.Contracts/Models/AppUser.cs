namespace AuctionSystem.Contracts.Models
{
    public class AppUser : EntityBase
    {
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public AppUserType AppUserType { get; set; }
    }
}