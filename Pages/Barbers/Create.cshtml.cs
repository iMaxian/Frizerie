using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Frizerie.Data;
using Frizerie.Models;

namespace Frizerie.Pages.Barbers
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
            return Page();
        }

        [BindProperty]
        public Barber Barber { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Barber == null || Barber == null)
            {
                return Page();
            }

            _context.Barber.Add(Barber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
