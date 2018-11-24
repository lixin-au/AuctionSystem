using System.Collections.Generic;
using System.Security.Claims;

namespace AuctionSystem.Contracts.Models
{
    public class AppUser : EntityBase
    {
        public bool CanSell { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        public ClaimsPrincipal ToClaimsPrincipal()
        {
            var claims = new List<Claim>
            {
                new Claim(CustomClaimTypes.Subject, Key.ToString()),
                new Claim(ClaimTypes.Email, Email),
            };

            if (CanSell)
                claims.Add(new Claim(ClaimTypes.Role, AppUserRoles.Seller));

            return new ClaimsPrincipal(
                new ClaimsIdentity(
                    claims));
        }
    }
}