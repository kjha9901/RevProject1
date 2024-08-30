using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_1.Models;

public partial class ShoppingApidbContext : DbContext
{
    public ShoppingApidbContext()
    {
    }

    public ShoppingApidbContext(DbContextOptions<ShoppingApidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<StockDetail> StockDetails { get; set; }

    public virtual DbSet<StoreDetail> StoreDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=GENTLEMANNPC\\KENNYSERVER;database=ShoppingAPIDB;integrated security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB9D942ED504");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customerID");
            entity.Property(e => e.CustomerIsMember).HasColumnName("customerIsMember");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customerName");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderDet__0809337D6286F438");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderID");
            entity.Property(e => e.OrderCustomerId).HasColumnName("orderCustomerID");
            entity.Property(e => e.OrderFastShipping).HasColumnName("orderFastShipping");
            entity.Property(e => e.OrderFromStore).HasColumnName("orderFromStore");
            entity.Property(e => e.OrderProductId).HasColumnName("orderProductID");
            entity.Property(e => e.OrderQuantity).HasColumnName("orderQuantity");

            entity.HasOne(d => d.OrderCustomer).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderCustomerId)
                .HasConstraintName("fk_orderCustomerID");

            entity.HasOne(d => d.OrderFromStoreNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderFromStore)
                .HasConstraintName("fk_orderFromStore");

            entity.HasOne(d => d.OrderProduct).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderProductId)
                .HasConstraintName("fk_orderProductID");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__ProductD__2D10D16AD99C1B25");

            entity.HasIndex(e => e.ProductName, "UQ__ProductD__0A9CBBE0F2856F11").IsUnique();

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("productId");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("productCategory");
            entity.Property(e => e.ProductImage)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("productImage");
            entity.Property(e => e.ProductName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("productPrice");
        });

        modelBuilder.Entity<StockDetail>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__StockDet__CBAD87430CC0ADAE");

            entity.Property(e => e.StockId)
                .ValueGeneratedNever()
                .HasColumnName("stockID");
            entity.Property(e => e.StockProductName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("stockProductName");
            entity.Property(e => e.StockQuantity).HasColumnName("stockQuantity");
            entity.Property(e => e.StockStoreId).HasColumnName("stockStoreID");

            entity.HasOne(d => d.StockProductNameNavigation).WithMany(p => p.StockDetails)
                .HasPrincipalKey(p => p.ProductName)
                .HasForeignKey(d => d.StockProductName)
                .HasConstraintName("fk_stockProductName");

            entity.HasOne(d => d.StockStore).WithMany(p => p.StockDetails)
                .HasForeignKey(d => d.StockStoreId)
                .HasConstraintName("fk_stockStoreID");
        });

        modelBuilder.Entity<StoreDetail>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__StoreDet__1EA71633D396636A");

            entity.Property(e => e.StoreId)
                .ValueGeneratedNever()
                .HasColumnName("storeID");
            entity.Property(e => e.StoreCity)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("storeCity");
            entity.Property(e => e.StoreName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("storeName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
