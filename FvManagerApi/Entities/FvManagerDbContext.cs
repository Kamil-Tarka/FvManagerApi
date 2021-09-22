using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FvManagerApi.Entities
{
    public class FvManagerDbContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoicePossition> InvoicePossition { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

        public FvManagerDbContext(DbContextOptions<FvManagerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Company>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(180);

            modelBuilder.Entity<Company>()
                .Property(c => c.Nip)
                .HasMaxLength(10);

            modelBuilder.Entity<Company>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Company>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Company>()
                .Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.InvoiceNumber)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Seller)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Buyer)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PaymentType>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.NetPrice)
                .IsRequired()
                .HasPrecision(19, 2);

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(80);

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.UserEmail)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.IsActive)
                .IsRequired();

            modelBuilder.Entity<InvoicePossition>()
                .Property(i => i.NetPrice)
                .IsRequired()
                .HasPrecision(19, 2);

            modelBuilder.Entity<InvoicePossition>()
                .HasOne(i => i.Invoice)
                .WithMany(ip => ip.InvoicePossitions)
                .HasForeignKey(k => k.InvoiceId);

            modelBuilder.Entity<InvoicePossition>()
                .HasOne(p => p.Porduct)
                .WithMany(ip => ip.InvoicePossitions)
                .HasForeignKey(k => k.ProductId);

        }
    }
}
