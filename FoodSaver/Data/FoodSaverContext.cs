using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodSaver.Data
{
    public class FoodSaverContext : DbContext
    {
        public FoodSaverContext (DbContextOptions<FoodSaverContext> options)
            : base(options)
        {
        }

        public DbSet<FoodWaste> FoodWastes { get; set; } = default!;
        public DbSet<Product> Products { get; set; }
    }
}
