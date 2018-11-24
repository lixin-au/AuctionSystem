using System;

namespace AuctionSystem.Contracts.Models
{
    public class TokenSet
    {
        public string AccessToken { get; set; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(1);
        public bool IsExpired => DateTimeOffset.UtcNow.Subtract(TimeIssued) > Expiration;
        public DateTimeOffset TimeIssued { get; set; } = DateTimeOffset.UtcNow;
    }
}