using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Frizerie.Data;
using Frizerie.Models;

namespace Frizerie.Pages.Servicii
{
    public class CreateModel : PageModel
    {
        private readonly Frizerie.Data.FrizerieContext _context;

        public CreateModel(Frizerie.Data.FrizerieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BarberID"] = new SelectList(_context.Set<Barber>(), "ID", "ID");
        ViewData["BarberShopID"] = new SelectList(_context.Set<BarberShop>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Serviciu == null || Serviciu == null)
            {
                return Page();
            }

            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
