using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frizerie.Models;

namespace Frizerie.Data
{
    public class FrizerieContext : DbContext
    {
        public FrizerieContext (DbContextOptions<FrizerieContext> options)
            : base(options)
        {
        }

        public DbSet<Frizerie.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Frizerie.Models.Barber>? Barber { get; set; }

        //public DbSet<Frizerie.Models.Categorie>? Categorie { get; set; }
    }
}
