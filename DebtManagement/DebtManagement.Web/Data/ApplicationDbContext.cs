/*using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Web.Models;

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

            // Configuring the relationship between Client and Debt
            modelBuilder.Entity<Debt>()
                .HasOne(d => d.Client)
                .WithMany(c => c.Debts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring the relationship between Debt and Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Debt)
                .WithMany(d => d.Payments)
                .HasForeignKey(p => p.DebtId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring the relationship between Client and Income
            modelBuilder.Entity<Income>()
                .HasOne(i => i.Client)
                .WithMany(c => c.Incomes)
                .HasForeignKey(i => i.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure precision for decimal fields to avoid truncation
            modelBuilder.Entity<Debt>(entity =>
            {
                entity.Property(e => e.DebtAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.RemainingAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.EarlyClosingAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.InterestRateMonthly).HasColumnType("decimal(18,2)");
                entity.Property(e => e.InterestRateYearly).HasColumnType("decimal(18,2)");
                entity.Property(e => e.InsuranceAmount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.AmountPaid).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.Property(e => e.MonthlyIncome).HasColumnType("decimal(18,2)");
            });
        }
    }
}
*/
/*
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Web.Models;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure the precision for decimal fields in the Debt entity
            builder.Entity<Debt>()
                .Property(d => d.DebtAmount)
                .HasColumnType("decimal(18,2)");
            builder.Entity<Debt>()
                .Property(d => d.EarlyClosingAmount)
                .HasColumnType("decimal(18,2)");
            builder.Entity<Debt>()
                .Property(d => d.InsuranceAmount)
                .HasColumnType("decimal(18,2)");
            builder.Entity<Debt>()
                .Property(d => d.InterestRateMonthly)
                .HasColumnType("decimal(18,2)");
            builder.Entity<Debt>()
                .Property(d => d.InterestRateYearly)
                .HasColumnType("decimal(18,2)");
            builder.Entity<Debt>()
                .Property(d => d.RemainingAmount)
                .HasColumnType("decimal(18,2)");

            // Configure the precision for decimal fields in the Income entity
            builder.Entity<Income>()
                .Property(i => i.MonthlyIncome)
                .HasColumnType("decimal(18,2)");

            // Configure the precision for decimal fields in the Payment entity
            builder.Entity<Payment>()
                .Property(p => p.AmountPaid)
                .HasColumnType("decimal(18,2)");
        }
    }
}
*/
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Web.Models;

namespace DebtManagement.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Income> Incomes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Apply configurations for the User model
            builder.Entity<User>(entity =>
            {
                entity.Property(u => u.ClientName).IsRequired();
            });

            // Apply configurations for the Debt model
            builder.Entity<Debt>(entity =>
            {
                entity.HasKey(d => d.DebtId);
                entity.Property(d => d.DebtAmount).HasColumnType("decimal(18,2)");
                entity.Property(d => d.RemainingAmount).HasColumnType("decimal(18,2)");
                entity.Property(d => d.EarlyClosingAmount).HasColumnType("decimal(18,2)");
                entity.Property(d => d.InterestRateMonthly).HasColumnType("decimal(18,2)");
                entity.Property(d => d.InterestRateYearly).HasColumnType("decimal(18,2)");
                entity.Property(d => d.InsuranceAmount).HasColumnType("decimal(18,2)");
                entity.HasOne(d => d.Client)
                      .WithMany(c => c.Debts)
                      .HasForeignKey(d => d.ClientId);
            });

            // Apply configurations for the Payment model
            builder.Entity<Payment>(entity =>
            {
                entity.HasKey(p => p.PaymentId);
                entity.Property(p => p.AmountPaid).HasColumnType("decimal(18,2)");
                entity.HasOne(p => p.Debt)
                      .WithMany(d => d.Payments)
                      .HasForeignKey(p => p.DebtId);
            });

            // Apply configurations for the Income model
            builder.Entity<Income>(entity =>
            {
                entity.HasKey(i => i.IncomeId);
                entity.Property(i => i.MonthlyIncome).HasColumnType("decimal(18,2)");
                entity.HasOne(i => i.Client)
                      .WithMany(c => c.Incomes)
                      .HasForeignKey(i => i.ClientId);
            });
        }
    }
}*/


/*
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Web.Models;

namespace DebtManagement.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }

        public DbSet<Debt> Debts { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
*/
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Web.Models;

namespace DebtManagement.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Income> Incomes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
