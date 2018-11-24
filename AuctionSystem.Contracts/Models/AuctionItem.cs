using System;

namespace AuctionSystem.Contracts.Models
{
    public class AuctionItem : EntityBase
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal ReservePrice { get; set; }
        public DateTimeOffset TimeClosed { get; set; }
        public DateTimeOffset? TimeStarted { get; set; }
        public virtual Bid WinningBid { get; set; }
    }
}