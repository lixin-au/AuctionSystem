using System;

namespace AuctionSystem.Contracts.Models
{
    public class EntityBase
    {
        public Guid Key { get; set; }
        public long RelationalId { get; set; }
    }
}