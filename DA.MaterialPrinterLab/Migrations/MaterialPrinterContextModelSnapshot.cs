﻿// <auto-generated />
using System;
using DA.MaterialPrinterLab;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DA.MaterialPrinterLab.Migrations
{
    [DbContext(typeof(MaterialPrinterContext))]
    partial class MaterialPrinterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EL.MaterialPrinterLab.Models.Impresora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Imprimiendo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Impresoras");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EsBase")
                        .HasColumnType("bit");

                    b.Property<int?>("ImpresoraId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("Tiempo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImpresoraId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Models.OrdenImpresion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DuracionEstimada")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("FechaEjecucion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFinalizacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImpresoraId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemFinalId")
                        .HasColumnType("int");

                    b.Property<string>("Solicitante")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ImpresoraId");

                    b.HasIndex("ItemFinalId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Models.Receta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("InsumoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsumoId");

                    b.ToTable("Receta");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Models.Item", b =>
                {
                    b.HasOne("EL.MaterialPrinterLab.Models.Impresora", null)
                        .WithMany("Cola")
                        .HasForeignKey("ImpresoraId");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Models.OrdenImpresion", b =>
                {
                    b.HasOne("EL.MaterialPrinterLab.Models.Impresora", "Impresora")
                        .WithMany()
                        .HasForeignKey("ImpresoraId");

                    b.HasOne("EL.MaterialPrinterLab.Models.Item", "ItemFinal")
                        .WithMany()
                        .HasForeignKey("ItemFinalId");

                    b.Navigation("Impresora");

                    b.Navigation("ItemFinal");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Models.Receta", b =>
                {
                    b.HasOne("EL.MaterialPrinterLab.Models.Item", "Insumo")
                        .WithMany("Receta")
                        .HasForeignKey("InsumoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumo");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Models.Impresora", b =>
                {
                    b.Navigation("Cola");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Models.Item", b =>
                {
                    b.Navigation("Receta");
                });
#pragma warning restore 612, 618
        }
    }
}
