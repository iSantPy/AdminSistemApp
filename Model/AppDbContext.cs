using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ControlAguaPotable.Model
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Sell> Sells { get; set; }
        public DbSet<SellDetail> SellsDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillsDetails { get; set; }
        public DbSet<IncomeBs> IncomeBs { get; set; }
        public DbSet<IncomeDollars> IncomeDollars { get; set; }
        public DbSet<WithdrawalBs> WithdrawalBs { get; set; }
        public DbSet<WithdrawalDollars> WithdrawalDollars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sell>()
                .HasKey(s => s.ID);

            modelBuilder.Entity<Sell>()
                .Property(s => s.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SellDetail>()
                .HasKey(sd => sd.ID);

            modelBuilder.Entity<SellDetail>()
                .Property(sd => sd.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SellDetail>()
                .HasOne(sd => sd.Sell)
                .WithMany(s => s.Details)
                .HasForeignKey(sd => sd.SellID);

            modelBuilder.Entity<Bill>()
                .HasKey(b => b.ID);

            modelBuilder.Entity<Bill>()
                .Property(b => b.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BillDetail>()
                .HasKey(b => b.ID);

            modelBuilder.Entity<BillDetail>()
                .Property(b => b.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BillDetail>()
                .HasOne(bd => bd.Bill)
                .WithMany(b => b.Details)
                .HasForeignKey(bd => bd.BillID);

            modelBuilder.Entity<IncomeBs>()
                .HasKey(i => i.ID);

            modelBuilder.Entity<IncomeBs>()
                .Property(i => i.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Sell>()
                .HasOne(s => s.IncomeBs) 
                .WithOne(i => i.Sell)    
                .HasForeignKey<IncomeBs>(i => i.SellID);

            modelBuilder.Entity<IncomeDollars>()
                .HasKey(i => i.ID);

            modelBuilder.Entity<IncomeDollars>()
                .Property(i => i.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Sell>()
                .HasOne(s => s.IncomeDollars)
                .WithOne(i => i.Sell)
                .HasForeignKey<IncomeDollars>(i => i.SellID);

            modelBuilder.Entity<WithdrawalBs>()
                .HasKey(w => w.ID);

            modelBuilder.Entity<WithdrawalBs>()
                .Property(w => w.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Sell>()
                .HasOne(s => s.WithdrawalBs)
                .WithOne(w => w.Sell)
                .HasForeignKey<WithdrawalBs>(w => w.SellID);

            modelBuilder.Entity<WithdrawalDollars>()
                .HasKey(w => w.ID);

            modelBuilder.Entity<WithdrawalDollars>()
                .Property(w => w.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Sell>()
                .HasOne(s => s.WithdrawalDollars)
                .WithOne(w => w.Sell)
                .HasForeignKey<WithdrawalDollars>(w => w.SellID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
