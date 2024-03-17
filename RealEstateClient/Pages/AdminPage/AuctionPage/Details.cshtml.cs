using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using System.Net.Http.Headers;
using BusinessObject.DTO.Request;
using System.Text.Json;
using BusinessObject.DTO.Response;

namespace RealEstateClient.Pages.AdminPage.AuctionPage
{
    public class DetailsModel : PageModel
    {

        private readonly HttpClient _httpClient;
        private string ApiUrl = "";

        public DetailsModel()
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
