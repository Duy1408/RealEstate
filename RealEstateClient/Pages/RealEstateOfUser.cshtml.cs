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

namespace RealEstateClient.Pages
{
    public class RealEstateOfUserModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ApiUrl = "";

        public RealEstateOfUserModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/RealEstates";
        }

        public IList<RealEstateResponseDTO> RealEstate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage response = await client.GetAsync($"{ApiUrl}/byuserid/{id}?id={id}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _realEstate = JsonSerializer.Deserialize<List<RealEstateResponseDTO>>(strData, options)!;

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
