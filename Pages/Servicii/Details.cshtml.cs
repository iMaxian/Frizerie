﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Frizerie.Data.FrizerieContext _context;

        public DetailsModel(Frizerie.Data.FrizerieContext context)
        {
            _context = context;
        }

      public Serviciu Serviciu { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            if (serviciu == null)
            {
                return NotFound();
            }
            else 
            {
                Serviciu = serviciu;
            }
            return Page();
        }
    }
}
