using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.BusinessObject;
using System.Net.Http.Headers;
using BusinessObject.ViewModels;
using System.Text.Json;
using Microsoft.Win32;

namespace RealEstateClient.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";

        public RegisterModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Users";

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RegisterVM User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                string strData = JsonSerializer.Serialize(User);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{ApiUrl}/Register", contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Register successfully";
                    return RedirectToPage("/Login");

                }
            }
            catch
            {
                ViewData["ErrorMessage"] = "Fail To Call API";

                return Page();
            }

            return RedirectToPage("/Error");
        }
    }
}
