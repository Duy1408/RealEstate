using BusinessObject.BusinessObject;
using BusinessObject.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RealEstateClient.Pages
{
    public class RealEstateDetailsModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ApiUrl = "";

        public RealEstateDetailsModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/RealEstates";
        }

        public RealEstateResponseDTO RealEstate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage response = await client.GetAsync($"{ApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _realEstate = JsonSerializer.Deserialize<RealEstateResponseDTO>(strData, options)!;

            var realEstate = _realEstate;

            if (realEstate == null)
            {
                return NotFound();
            }
            RealEstate = realEstate;

            return Page();
        }
    }
}
