using System.Collections.Generic;
using System.Security.Claims;

namespace AuctionSystem.Contracts.Models
{
    public class AppUser : EntityBase
    {
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public AppUserType AppUserType { get; set; }

        public ClaimsPrincipal ToClaimsPrincipal()
        {
            return new ClaimsPrincipal(
                new ClaimsIdentity(
                    new List<Claim>
                    {
                        new Claim(CustomClaimTypes.Subject, Key.ToString()),
                        new Claim(ClaimTypes.Email, Email),
                        new Claim(ClaimTypes.Role, AppUserType.ToString())
                    }));
        }
    }
}