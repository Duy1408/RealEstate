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

namespace RealEstateClient.Pages.AdminPage.CommentPage
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";
        public DeleteModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Comments";
        }

        [BindProperty]
        public Comment Comment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{ApiUrl}/{id}");
            string strData = await responseMessage.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var comments = JsonSerializer.Deserialize<Comment>(strData, options)!;

            Comment = comments;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{ApiUrl}/{id}");
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
