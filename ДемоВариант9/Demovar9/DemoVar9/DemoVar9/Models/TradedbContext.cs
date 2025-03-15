using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DemoVar9.Models;

public partial class TradedbContext : DbContext
{
    public TradedbContext()
    {
    }

    public TradedbContext(DbContextOptions<TradedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderPoint> OrderPoints { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=tradedb", ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.IdManufacturer).HasName("PRIMARY");

            entity.ToTable("manufacturer");

            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.IdOrderPoint, "fk_order_point_order_idx");

            entity.HasIndex(e => e.IdStatus, "fk_order_status_order_idx");

            entity.HasIndex(e => e.IdUser, "fk_user_order_idx");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DateDelivery).HasColumnName("date_delivery");
            entity.Property(e => e.DateOrder).HasColumnName("date_order");
            entity.Property(e => e.IdOrderPoint).HasColumnName("id_order_point");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.ProductInOrder)
                .HasMaxLength(500)
                .HasColumnName("product_in_order");

            entity.HasOne(d => d.IdOrderPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdOrderPoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_point_order");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_status_order");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_order");
        });

        modelBuilder.Entity<OrderPoint>(entity =>
        {
            entity.HasKey(e => e.IdOrderPoint).HasName("PRIMARY");

            entity.ToTable("order_point");

            entity.Property(e => e.IdOrderPoint).HasColumnName("id_order_point");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.House)
                .HasMaxLength(100)
                .HasColumnName("house");
            entity.Property(e => e.PostIndex).HasColumnName("post_index");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasColumnName("street");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.IdOrderStatus).HasName("PRIMARY");

            entity.ToTable("order_status");

            entity.Property(e => e.IdOrderStatus).HasColumnName("id_order_status");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.IdManufacturer, "fk_manufacturer_product_idx");

            entity.HasIndex(e => e.IdProductCategory, "fk_product_category_product_idx");

            entity.HasIndex(e => e.IdSupplier, "fk_supplier_product_idx");

            entity.Property(e => e.IdProduct)
                .HasMaxLength(100)
                .HasColumnName("id_product");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.CurrentDiscount).HasColumnName("current_discount");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.IdProductCategory).HasColumnName("id_product_category");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .HasColumnName("image");
            entity.Property(e => e.MaxDiscount).HasColumnName("max_discount");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasMaxLength(45)
                .HasColumnName("position");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdManufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_manufacturer_product");

            entity.HasOne(d => d.IdProductCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_category_product");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_supplier_product");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.IdProductCategory).HasName("PRIMARY");

            entity.ToTable("product_category");

            entity.Property(e => e.IdProductCategory).HasColumnName("id_product_category");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("PRIMARY");

            entity.ToTable("supplier");

            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Role, "fk_role_user_idx");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Login)
                .HasMaxLength(200)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.Patronimyc)
                .HasMaxLength(100)
                .HasColumnName("patronimyc");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
