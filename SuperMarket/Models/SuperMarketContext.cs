using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SuperMarket.Models
{
    public partial class SuperMarketContext : DbContext
    {
        public SuperMarketContext()
        {
        }

        public SuperMarketContext(DbContextOptions<SuperMarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Customer ID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer Address");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer Name");

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Customer PhoneNumber");

                entity.Property(e => e.StaffId).HasColumnName("Staff ID");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Customer");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer ID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product Name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Product Price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Product_Product");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId)
                    .ValueGeneratedNever()
                    .HasColumnName("Staff ID");

                entity.Property(e => e.StaffAddress)
                    .IsUnicode(false)
                    .HasColumnName("Staff Address");

                entity.Property(e => e.StaffFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Staff First Name");

                entity.Property(e => e.StaffLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Staff Last Name");

                entity.Property(e => e.StaffPhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Staff Phone Number");

                entity.Property(e => e.StaffStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Staff Status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
