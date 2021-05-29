﻿using EL.MaterialPrinterLab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MaterialPrinterLab
{
    public class MaterialPrinterContext : DbContext
    {
        private readonly string _ConnectionString;

        public MaterialPrinterContext(DbContextOptions options) : base(options) { }

        public MaterialPrinterContext(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_ConnectionString))
            {
                optionsBuilder.UseSqlServer(_ConnectionString);
            }
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Impresora> Impresoras { get; set; }
        public DbSet<OrdenImpresion> Ordenes { get; set; }
    }
}
