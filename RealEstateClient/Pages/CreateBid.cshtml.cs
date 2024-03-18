using BusinessObject.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RealEstateClient.Pages
{
    public class CreateBidModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ApiUrl = "";
        public CreateBidModel()
        {

            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Bids";
        }
        public IActionResult OnGet()
        {
            return Page();
        }


        [BindProperty]
        public Bid Bid { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                string strData = JsonSerializer.Serialize(Bid);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApiUrl, contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Add New Bid successfully";
                    ViewData["Success"] = "Please wait for approve";
                    return Page();
                }

            }
            catch
            {
                ViewData["ErrorMessage"] = "Fail To Call API";

                return Page();
            }

            return RedirectToPage("./UserProfile");
        }
    }
}
