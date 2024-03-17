using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.BusinessObject;

namespace RealEstateClient.Pages.AdminPage.PropertyPage
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.BusinessObject.TheRealEstateDBContext _context;

        public CreateModel(BusinessObject.BusinessObject.TheRealEstateDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RealEstateID"] = new SelectList(_context.RealEstates, "RealEstateID", "Description");
            return Page();
        }

        [BindProperty]
        public Propertie Propertie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Properties == null || Propertie == null)
            {
                return Page();
            }

            _context.Properties.Add(Propertie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
