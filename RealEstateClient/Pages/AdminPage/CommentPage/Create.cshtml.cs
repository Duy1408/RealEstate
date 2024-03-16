using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.BusinessObject;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RealEstateClient.Pages.AdminPage.CommentPage
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ApiUrl = "";

        public CreateModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Comments";

        }

        [BindProperty]
        public Comment Comment { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                string strData = JsonSerializer.Serialize(Comment);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(ApiUrl, contentData);
                if (responseMessage.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Add new Comments successfully";
                    return RedirectToPage("./Index");
                }
            }
            catch
            {
                ViewData["ErrorMessage"] = "Fail To Call API";
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
