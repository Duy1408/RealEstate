using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using System.Net.Http.Headers;
using System.Text.Json;
using BusinessObject.DTO.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RealEstateClient.Pages.AdminPage.AuctionPage
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ApiUrl = "";

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Auctions";

        }
        public IList<AuctionResponseDTO> Auction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var token = HttpContext.Request.Cookies["AdminCookie"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Login"); // Không tìm thấy token trong cookie
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token) as JwtSecurityToken;
            var roleClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (roleClaim?.Value == "Admin")
            {
                HttpResponseMessage response = await client.GetAsync(ApiUrl);
                string strData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<AuctionResponseDTO> auctions = JsonSerializer.Deserialize<List<AuctionResponseDTO>>(strData, options)!;

                Auction = auctions;

                return Page();
            }
            return Page();
        }
    }
}
