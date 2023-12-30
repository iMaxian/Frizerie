﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Frizerie.Data.FrizerieContext _context;

        public DetailsModel(Frizerie.Data.FrizerieContext context)
        {
            _context = context;
        }

      public Barber Barber { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Barber == null)
            {
                return NotFound();
            }

            var barber = await _context.Barber.FirstOrDefaultAsync(m => m.ID == id);
            if (barber == null)
            {
                return NotFound();
            }
            else 
            {
                Barber = barber;
            }
            return Page();
        }
    }
}
