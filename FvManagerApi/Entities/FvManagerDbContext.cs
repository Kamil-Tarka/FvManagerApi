using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FvManagerApi.Entities
{
    public class FvManagerDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoicePossition> InvoicePossition { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserCompanies> UserCompanies { get; set; }

        public FvManagerDbContext(DbContextOptions<FvManagerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Company>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(180);

            modelBuilder.Entity<Company>()
                .Property(c => c.Nip)
                .HasMaxLength(10);

            modelBuilder.Entity<Company>()
                .Property(c => c.IsPhisicalPerson)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .Property(c => c.AddressId)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.InvoiceNumber)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.DateOfInvoice)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.DateOfSale)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.DateOfPayment)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.PaymentTypeId)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.SellerId)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Seller)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.BuyerId)
                .IsRequired();

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
                .HasPrecision(19,4);

            modelBuilder.Entity<Product>()
                .Property(p => p.TaxRate)
                .IsRequired();

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

            modelBuilder.Entity<InvoicePossition>()
                .HasOne(i => i.Invoice)
                .WithMany(ip => ip.InvoicePossitions)
                .HasForeignKey(k => k.InvoiceId);

            modelBuilder.Entity<InvoicePossition>()
                .HasOne(p => p.Porduct)
                .WithMany(ip => ip.InvoicePossitions)
                .HasForeignKey(k => k.ProductId);

            modelBuilder.Entity<UserCompanies>()
                .HasOne(u => u.User)
                .WithMany(uc => uc.UserCompanies)
                .HasForeignKey(k => k.UserId);

            modelBuilder.Entity<UserCompanies>()
                .HasOne(c => c.Company)
                .WithMany(uc => uc.UserCompanies)
                .HasForeignKey(k => k.CompanyId);
        }
    }
}
