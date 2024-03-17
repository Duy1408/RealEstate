using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;

namespace RealEstateClient.Pages.AdminPage.PropertyPage
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.BusinessObject.TheRealEstateDBContext _context;

        public DetailsModel(BusinessObject.BusinessObject.TheRealEstateDBContext context)
        {
            _context = context;
        }

      public Propertie Propertie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Properties == null)
            {
                return NotFound();
            }

            var propertie = await _context.Properties.FirstOrDefaultAsync(m => m.PID == id);
            if (propertie == null)
            {
                return NotFound();
            }
            else 
            {
                Propertie = propertie;
            }
            return Page();
        }
    }
}
