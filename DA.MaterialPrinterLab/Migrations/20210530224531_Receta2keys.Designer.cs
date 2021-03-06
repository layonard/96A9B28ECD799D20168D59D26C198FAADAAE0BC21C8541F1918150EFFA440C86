// <auto-generated />
using System;
using DA.MaterialPrinterLab;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DA.MaterialPrinterLab.Migrations
{
    [DbContext(typeof(MaterialPrinterContext))]
    [Migration("20210530224531_Receta2keys")]
    partial class Receta2keys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EL.MaterialPrinterLab.Model.Impresora", b =>
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

            modelBuilder.Entity("EL.MaterialPrinterLab.Model.Insumo", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("InsumoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "InsumoId");

                    b.HasIndex("InsumoId");

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EsBase")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("Tiempo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Model.OrdenImpresion", b =>
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

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Solicitante")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ImpresoraId");

                    b.HasIndex("ItemId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Model.Insumo", b =>
                {
                    b.HasOne("EL.MaterialPrinterLab.Model.Item", "InsumoItem")
                        .WithMany()
                        .HasForeignKey("InsumoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EL.MaterialPrinterLab.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InsumoItem");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("EL.MaterialPrinterLab.Model.OrdenImpresion", b =>
                {
                    b.HasOne("EL.MaterialPrinterLab.Model.Impresora", "Impresora")
                        .WithMany()
                        .HasForeignKey("ImpresoraId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EL.MaterialPrinterLab.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Impresora");

                    b.Navigation("Item");
                });
#pragma warning restore 612, 618
        }
    }
}
