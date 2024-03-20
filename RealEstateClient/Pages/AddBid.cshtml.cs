using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RealEstateClient.Pages
{
    public class AddBidModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private string ApiUrl = "";

        public AddBidModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Bids";
        }

        [BindProperty]
        public Bid Bid { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{ApiUrl}/{id}");
            string strData = await responseMessage.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var bids = JsonSerializer.Deserialize<Bid>(strData, options)!;


            Bid = bids;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    try
        //    {
        //        string strData = JsonSerializer.Serialize(Bid);
        //        var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await _httpClient.PutAsync($"{ApiUrl}?id={id}", contentData);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            ViewData["Message"] = "Add New Bid successfully";
        //            ViewData["Success"] = "Please wait for approve";
        //            return Page();
        //        }
        //        ViewData["Error"] = "Update Error";
        //        return RedirectToPage("./UserProfile");
        //    }
        //    catch
        //    {
        //        ViewData["Error"] = "Fail To Call API";
        //        return RedirectToPage("/Error");
        //    }
        //}

        public async Task<IActionResult> OnPostAsync(int? id, double additionalBidAmount)
        {
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{ApiUrl}/{id}");
                string strData = await responseMessage.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var currentBid = JsonSerializer.Deserialize<Bid>(strData, options)!;

                currentBid.BidAmount += additionalBidAmount;
                currentBid.Status = false;

                string updatedBidData = JsonSerializer.Serialize(currentBid);

                var contentData = new StringContent(updatedBidData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync($"{ApiUrl}?id={id}", contentData);

                if (response.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Add New Bid successfully";
                    ViewData["Success"] = "Please wait for approve";
                    return Page();
                }

                ViewData["Error"] = "Update Error";
                return RedirectToPage("./UserProfile");
            }
            catch
            {
                ViewData["Error"] = "Fail To Call API";
                return RedirectToPage("/Error");
            }
        }

    }
}
