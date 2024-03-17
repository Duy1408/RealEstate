using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RealEstateClient.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            Response.Cookies.Delete("UserCookie");
            Response.Cookies.Delete("AdminCookie");
            return RedirectToPage("/HomePage");
        }
    }
}
