namespace AuctionSystem.Contracts.Models
{
    public class Bid : EntityBase
    {
        public virtual AppUser AppUser { get; set; }
        public decimal Price { get; set; }
    }
}