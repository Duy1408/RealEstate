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
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.BusinessObject.TheRealEstateDBContext _context;

        public DeleteModel(BusinessObject.BusinessObject.TheRealEstateDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Properties == null)
            {
                return NotFound();
            }
            var propertie = await _context.Properties.FindAsync(id);

            if (propertie != null)
            {
                Propertie = propertie;
                _context.Properties.Remove(Propertie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
