using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Frizerie.Data;
using Frizerie.Models;

namespace Frizerie.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly Frizerie.Data.FrizerieContext _context;

        public IndexModel(Frizerie.Data.FrizerieContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get;set; } = default!;

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ServiciuD = new ServiciuData();

            ServiciuD.Servicii = await _context.Serviciu
                .Include(b => b.Barber)
                .Include(b => b.ServiciuCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Tip_Serviciu)
                .ToListAsync();

            if (id != null)
            {
                ServiciuID = id.Value;
                Serviciu serviciu = ServiciuD.Servicii
                    .Where(id => id.ID == id.Value).Single();
                ServiciuD.Categories = serviciu.ServiciuCategories.Select(s => s.Category);
            }
            /*
            if (_context.Serviciu != null)
            {
                Serviciu = await _context.Serviciu
                .Include(s => s.Barber)
                .Include(s => s.BarberShop)
                .ToListAsync();
            }
            */
        }
    }
}
