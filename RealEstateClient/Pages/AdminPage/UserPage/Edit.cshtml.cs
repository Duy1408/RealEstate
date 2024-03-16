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
using BusinessObject.DTO;

namespace RealEstateClient.Pages.AdminPage.UserPage
{
    public class EditModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";

        public EditModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Users";
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage response = await client.GetAsync($"{ApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _user = JsonSerializer.Deserialize<UserDTO>(strData, options)!;

            User = _user;
            return Page();
        }

        [BindProperty]
        public UserDTO User { get; set; } = default!;

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                string strData = JsonSerializer.Serialize(User);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{ApiUrl}?id={id}", contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewData["Success"] = "Update Success";
                    return RedirectToPage("./Index");
                }
                ViewData["Error"] = "Update Error";
                return RedirectToPage("./Index");
            }
            catch
            {
                ViewData["Error"] = "Fail To Call API";
                return RedirectToPage("./Index");
            }
        }
    }
}
