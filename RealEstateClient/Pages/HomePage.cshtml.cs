using BusinessObject.BusinessObject;
using BusinessObject.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RealEstateClient.Pages
{
    public class HomePageModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ApiUrl = "";

        public HomePageModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/RealEstates";

        }
        public IList<RealEstateResponseDTO> RealEstate { get; set; } = default!;

        
        public async Task<IActionResult> OnGetAsync()
        {
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<RealEstateResponseDTO> listRealEstate = JsonSerializer.Deserialize<List<RealEstateResponseDTO>>(strData, options)!;

            RealEstate = listRealEstate;

            return Page();
        }
    }
}
