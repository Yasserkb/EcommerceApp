using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using EcommerceSite.Models;

namespace EcommerceSite.Data
{
    public class EcommerceSiteContext : DbContext
    {
        public EcommerceSiteContext (DbContextOptions<EcommerceSiteContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; } = default!;

        public DbSet<MvcMovie.Models.Products> Product { get; set; } = default!;

        public DbSet<EcommerceSite.Models.Panier> Panier { get; set; } = default!;

        public DbSet<EcommerceSite.Models.LignePanier> LignePanier { get; set; } = default!;
    }
}
