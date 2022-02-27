using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamblingApi.Models
{
    public class DbContextModel : DbContext
    {
        public DbContextModel (DbContextOptions<DbContextModel> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>()
                .HasOne(u => u.UserModel)
                .WithOne(a => a.Account)
                .HasForeignKey<AccountModel>(a => a.UserId);

            modelBuilder.Entity<OrderModel>()
               .HasOne(u => u.UserModel)
                .WithMany(o => o.Orders)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<AccountModel>().Property(p => p.Balance).HasColumnType("decimal(18,4)");
            base.OnModelCreating(modelBuilder);
        }
    }
}
