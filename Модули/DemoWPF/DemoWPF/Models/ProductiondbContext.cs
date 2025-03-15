using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DemoWPF.Models;

public partial class ProductiondbContext : DbContext
{
    public ProductiondbContext()
    {
    }

    public ProductiondbContext(DbContextOptions<ProductiondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Materialtype> Materialtypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Partnerproduct> Partnerproducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Producttype> Producttypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=productiondb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Materialtype>(entity =>
        {
            entity.HasKey(e => e.MaterialTypeId).HasName("PRIMARY");

            entity.ToTable("materialtypes");

            entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");
            entity.Property(e => e.DefectPercentage).HasPrecision(5, 4);
            entity.Property(e => e.MaterialTypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PartnerId).HasName("PRIMARY");

            entity.ToTable("partners");

            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.House).HasMaxLength(255);
            entity.Property(e => e.Inn)
                .HasMaxLength(255)
                .HasColumnName("INN");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PartnerName).HasMaxLength(255);
            entity.Property(e => e.PartnerType).HasMaxLength(255);
            entity.Property(e => e.Patronymic).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.Region).HasMaxLength(255);
            entity.Property(e => e.Street).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(255);
        });

        modelBuilder.Entity<Partnerproduct>(entity =>
        {
            entity.HasKey(e => e.PartnerProductId).HasName("PRIMARY");

            entity.ToTable("partnerproducts");

            entity.HasIndex(e => e.PartnerId, "PartnerID");

            entity.HasIndex(e => e.ProductId, "ProductID");

            entity.Property(e => e.PartnerProductId).HasColumnName("PartnerProductID");
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SaleDate).HasColumnType("timestamp");

            entity.HasOne(d => d.Partner).WithMany(p => p.Partnerproducts)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("partnerproducts_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.Partnerproducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("partnerproducts_ibfk_2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.ProductTypeId, "ProductTypeID");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.MinPartnerPrice).HasPrecision(10, 2);
            entity.Property(e => e.ProductArticle).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .HasConstraintName("products_ibfk_1");
        });

        modelBuilder.Entity<Producttype>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("PRIMARY");

            entity.ToTable("producttypes");

            entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");
            entity.Property(e => e.ProductTypeCoefficient).HasPrecision(10, 2);
            entity.Property(e => e.ProductTypeName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
