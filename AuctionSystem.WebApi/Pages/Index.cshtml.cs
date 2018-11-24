using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuctionSystem.WebApi.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return new StatusCodeResult((int) HttpStatusCode.Unauthorized);
        }
    }
}