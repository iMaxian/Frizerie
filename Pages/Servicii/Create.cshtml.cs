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
    public class CreateModel : ServiciuCategoriesPageModel
    {
        private readonly Frizerie.Data.FrizerieContext _context;

        public CreateModel(Frizerie.Data.FrizerieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var barberList = _context.Barber.Select(x => new
            {
                x.ID,
                NumeComplet = x.Nume + " " + x.Prenume
            });

        ViewData["BarberID"] = new SelectList(_context.Set<Barber>(), "ID", "NumeComplet");
        ViewData["BarberShopID"] = new SelectList(_context.Set<BarberShop>(), "ID", "NumeComplet");

            var serviciu = new Serviciu();
            serviciu.ServiciuCategories = new List<ServiciuCategory>();
            PopulateAssignedCategoryData(_context, serviciu);

            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newServiciu = new Serviciu();
            if (selectedCategories != null)
            {
                newServiciu.ServiciuCategories = new List<ServiciuCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ServiciuCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newServiciu.ServiciuCategories.Add(catToAdd);
                }
            }
            Serviciu.ServiciuCategories = newServiciu.ServiciuCategories;
            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        /*
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
        */
    }
    
}
