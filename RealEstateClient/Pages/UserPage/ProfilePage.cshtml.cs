using BusinessObject.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace RealEstateClient.Pages.UserPage
{
    public class ProfilePageModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";

        public ProfilePageModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Users";
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public int UserID;
        public RealEstate RealEstate { get; set; } = default!;
        public int RealEstateID;


        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var token = HttpContext.Request.Cookies["UserCookie"];

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Login"); // Không tìm thấy token trong cookie
            }
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token) as JwtSecurityToken;
            var userIdClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;



            HttpResponseMessage response = await client.GetAsync($"{ApiUrl}/{userIdClaim}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _user = JsonSerializer.Deserialize<User>(strData, options)!;

            var _realEstate = JsonSerializer.Deserialize<RealEstate>(strData, options)!;

            RealEstate = _realEstate;

            User = _user;
            return Page();
        }
    }
}
