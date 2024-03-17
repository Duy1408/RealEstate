using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using System.Net.Http.Headers;
using BusinessObject.DTO.Response;
using System.Text.Json;

namespace RealEstateClient.Pages.AdminPage.PropertyPage
{
    public class IndexModel : PageModel
    {

        private readonly HttpClient client = null!;
        private string ApiUrl = "";

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Properties";

        }
        public IList<Propertie> Propertie { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Propertie> properties = JsonSerializer.Deserialize<List<Propertie>>(strData, options)!;

            Propertie = properties;

            return Page();
        }
    }
}
