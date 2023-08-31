using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MainProject.Data
{
    public class MainProjectContext : DbContext
    {
        public MainProjectContext (DbContextOptions<MainProjectContext> options)
            : base(options)
        {
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<UserDataRecord> UserDataRecords { get; set; }
    }
}
