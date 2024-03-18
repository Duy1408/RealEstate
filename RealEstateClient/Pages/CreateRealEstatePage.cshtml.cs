using BusinessObject.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace RealEstateClient.Pages
{
    public class CreateRealEstatePageModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";


        public CreateRealEstatePageModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/RealEstates";

        }


        [BindProperty]
        public RealEstate RealEstate { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                var token = HttpContext.Request.Cookies["UserCookie"];

                if (string.IsNullOrEmpty(token))
                {
                    return RedirectToPage("/Login"); // Không tìm thấy token trong cookie
                }
                else
                {

                    string strData = JsonSerializer.Serialize(RealEstate);
                    var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(ApiUrl, contentData);
                    if (response.IsSuccessStatusCode)
                    {
                        ViewData["Message"] = "Add New RealEstate successfully";
                        ViewData["Success"] = "Please wait for approve";
                        return Page();
                    }
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
