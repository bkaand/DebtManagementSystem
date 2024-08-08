/*using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Web.Entities;

namespace DebtManagement.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Income> Incomes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Debt>().ToTable("Debts");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Income>().ToTable("Incomes");

            modelBuilder.Entity<Debt>()
                .Property(d => d.DebtAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.EarlyClosingAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.InsuranceAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.InterestRateMonthly)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.InterestRateYearly)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.RemainingAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Income>()
                .Property(i => i.MonthlyIncome)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.AmountPaid)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .HasOne(d => d.Client)
                .WithMany(c => c.Debts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Debt)
                .WithMany(d => d.Payments)
                .HasForeignKey(p => p.DebtId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Income>()
                .HasOne(i => i.Client)
                .WithMany(c => c.Incomes)
                .HasForeignKey(i => i.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
*/

/*
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Web.Entities;

namespace DebtManagement.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Income> Incomes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Debt>().ToTable("Debts");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Income>().ToTable("Incomes");

            modelBuilder.Entity<Debt>()
                .Property(d => d.DebtAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.EarlyClosingAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.InsuranceAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.InterestRateMonthly)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.InterestRateYearly)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.RemainingAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Income>()
                .Property(i => i.MonthlyIncome)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.AmountPaid)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .HasOne(d => d.Client)
                .WithMany(c => c.Debts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Debt)
                .WithMany(d => d.Payments)
                .HasForeignKey(p => p.DebtId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Income>()
                .HasOne(i => i.Client)
                .WithMany(c => c.Incomes)
                .HasForeignKey(i => i.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
*/

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Web.Entities;

namespace DebtManagement.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Income> Incomes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Debt>().ToTable("Debts");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Income>().ToTable("Incomes");

            modelBuilder.Entity<Debt>()
                .Property(d => d.DebtAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.EarlyClosingAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.InsuranceAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.InterestRateMonthly)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.InterestRateYearly)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .Property(d => d.RemainingAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Income>()
                .Property(i => i.MonthlyIncome)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.AmountPaid)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Debt>()
                .HasOne(d => d.Client)
                .WithMany(c => c.Debts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Debt)
                .WithMany(d => d.Payments)
                .HasForeignKey(p => p.DebtId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Income>()
                .HasOne(i => i.Client)
                .WithMany(c => c.Incomes)
                .HasForeignKey(i => i.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
