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

namespace RealEstateClient.Pages.AdminPage.AuctionPage
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private string ApiUrl = "";
        public DeleteModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Auctions";
        }

        [BindProperty]
        public Auction Auction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{ApiUrl}/{id}");
            string strData = await responseMessage.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _auction = JsonSerializer.Deserialize<Auction>(strData, options)!;


            Auction = _auction;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    ViewData["Success"] = "Delete Success";
                    return RedirectToPage("./Index");
                }
                ViewData["Error"] = "Delete Error";
                return RedirectToPage("./Index");
            }
            catch
            {
                ViewData["Error"] = "Fail To Call API";
                return RedirectToPage("/Error");
            }
        }
    }
}
