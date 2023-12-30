using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Frizerie.Data;
using Frizerie.Models;

namespace Frizerie.Pages.Barbers
{
    public class IndexModel : PageModel
    {
        private readonly Frizerie.Data.FrizerieContext _context;

        public IndexModel(Frizerie.Data.FrizerieContext context)
        {
            _context = context;
        }

        public IList<Barber> Barber { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Barber != null)
            {
                Barber = await _context.Barber.ToListAsync();
            }
        }
    }
}
