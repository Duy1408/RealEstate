using BusinessObject.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RealEstateClient.Pages
{
    public class AuctionDetailPagesModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private string ApiUrl = "";

        public AuctionDetailPagesModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Auctions";
        }
        public AuctionResponseDTO Auction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{ApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _auction = JsonSerializer.Deserialize<AuctionResponseDTO>(strData, options)!;

            var auction = _auction;

            if (auction == null)
            {
                return NotFound();
            }
            Auction = auction;

            return Page();
        }
    }
}
