using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace _1DE.Models;

public partial class Db1deContext : DbContext
{
    public Db1deContext()
    {
    }

    public Db1deContext(DbContextOptions<Db1deContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderproduct> Orderproducts { get; set; }

    public virtual DbSet<Pickuppoint> Pickuppoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=db_1de", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasColumnType("text");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PRIMARY");

            entity.ToTable("manufacturers");

            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.ManufacturerName).HasColumnType("text");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.OrderPickupPointId, "OrderPickupPointID");

            entity.HasIndex(e => e.OrderUserId, "OrderUserID");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderCode).HasColumnType("text");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.OrderPickupPointId)
                .HasMaxLength(6)
                .HasColumnName("OrderPickupPointID")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.OrderStatus).HasColumnType("text");
            entity.Property(e => e.OrderUserId).HasColumnName("OrderUserID");

            entity.HasOne(d => d.OrderPickupPoint).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderPickupPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_1");

            entity.HasOne(d => d.OrderUser).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_2");
        });

        modelBuilder.Entity<Orderproduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("orderproduct");

            entity.HasIndex(e => e.ProductArticleNumber, "ProductArticleNumber");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductArticleNumber)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderproduct_ibfk_1");

            entity.HasOne(d => d.ProductArticleNumberNavigation).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.ProductArticleNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderproduct_ibfk_2");
        });

        modelBuilder.Entity<Pickuppoint>(entity =>
        {
            entity.HasKey(e => e.PickupPointId).HasName("PRIMARY");

            entity.ToTable("pickuppoints");

            entity.Property(e => e.PickupPointId)
                .HasMaxLength(6)
                .HasColumnName("PickupPointID")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PickupPointCity).HasColumnType("text");
            entity.Property(e => e.PickupPointStreet).HasColumnType("text");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductArticleNumber).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.ProductCategoryId, "ProductCategoryID");

            entity.HasIndex(e => e.ProductManufacturerId, "ProductManufacturerID");

            entity.HasIndex(e => e.ProductSupplierId, "ProductSupplierID");

            entity.Property(e => e.ProductArticleNumber)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ProductCost).HasPrecision(19, 4);
            entity.Property(e => e.ProductDescription).HasColumnType("text");
            entity.Property(e => e.ProductManufacturerId).HasColumnName("ProductManufacturerID");
            entity.Property(e => e.ProductMaxDiscountAmount).HasColumnType("text");
            entity.Property(e => e.ProductName).HasColumnType("text");
            entity.Property(e => e.ProductPhoto).HasColumnType("text");
            entity.Property(e => e.ProductSupplierId).HasColumnName("ProductSupplierID");
            entity.Property(e => e.ProductUnit).HasMaxLength(3);

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_1");

            entity.HasOne(d => d.ProductManufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_2");

            entity.HasOne(d => d.ProductSupplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductSupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_3");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.SupplierName).HasColumnType("text");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserRole, "UserRole");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserLogin).HasColumnType("text");
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPassword).HasColumnType("text");
            entity.Property(e => e.UserPatronymic).HasMaxLength(100);
            entity.Property(e => e.UserSurname).HasMaxLength(100);

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
