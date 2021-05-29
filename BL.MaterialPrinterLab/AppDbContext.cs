using System;
using Microsoft.EntityFrameworkCore;

namespace BL.MaterialPrinterLab
{
    public class AppDbContext : DbContext
    {
        private readonly string _ConnectionString;

        public AppDbContext(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
        }
    }
}
