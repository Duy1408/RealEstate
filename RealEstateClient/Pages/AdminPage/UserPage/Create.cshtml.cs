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

namespace RealEstateClient.Pages.AdminPage.UserPage
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";


        public CreateModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Users";

        }


        [BindProperty]
        public User User { get; set; } = default!;

        public string Admin { get; private set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //try
            //{
            //    Admin = HttpContext.Session.GetString("Admin")!;
            //    if (Admin != "Admin")
            //    {
            //        return NotFound();
            //    }
            //    if (Admin == null)
            //    {
            //        return NotFound();
            //    }
            //}
            //catch
            //{
            //    NotFound();
            //}
            try
            {

                string strData = JsonSerializer.Serialize(User);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApiUrl, contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Add New User successfully";
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
