using EL.MaterialPrinterLab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MaterialPrinterLab
{
    public class ImpresorasContext : DbContext
    {
        public ImpresorasContext(DbContextOptions options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Impresora> Impresoras { get; set; }
        public DbSet<OrdenImpresion> Ordenes { get; set; }
    }
}
