using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using BusinessObject.DTO.Request;
using System.Net.Http.Headers;
using System.Text.Json;
using BusinessObject.DTO.Response;

namespace RealEstateClient.Pages.AdminPage.RealEstatepage
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private string ApiUrl = "";

        public EditModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/RealEstates";
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{ApiUrl}/{id}");
            string strData = await responseMessage.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _realEstate = JsonSerializer.Deserialize<RealEstateUpdateDTO>(strData, options)!;


            RealEstate = _realEstate;
            return Page();
        }

        [BindProperty]
        public RealEstateUpdateDTO RealEstate { get; set; } = default!;

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                string strData = JsonSerializer.Serialize(RealEstate);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync($"{ApiUrl}?id={id}", contentData);
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
                return RedirectToPage("/Error");
            }
        }
    }
}
