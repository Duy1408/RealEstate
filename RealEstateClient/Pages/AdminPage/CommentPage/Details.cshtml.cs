using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using BusinessObject.ViewModels;

namespace RealEstateClient.Pages.AdminPage.CommentPage
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";

        public DetailsModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Comments";
        }

        public CommentVM Comment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage response = await client.GetAsync($"{ApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var comments = JsonSerializer.Deserialize<CommentVM>(strData, options)!;

            var commentCheck = comments;

            if (commentCheck == null)
            {
                return NotFound();
            }
            Comment = commentCheck;

            return Page();
        }
    }
}
