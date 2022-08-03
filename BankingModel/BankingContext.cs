using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RegisterationAPI.BankingModel
{
    public partial class BankingContext : DbContext
    {
        public BankingContext()
        {
        }

        public BankingContext(DbContextOptions<BankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-485\\SQLSERVERAKSHU;Database=Banking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.AccountNumber);

                entity.ToTable("UserAccount");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Account Number")
                    .IsFixedLength(true);

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Emailid).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Phone Number")
                    .IsFixedLength(true);

                entity.Property(e => e.Pin).HasColumnName("PIN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
