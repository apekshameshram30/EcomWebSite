using Application.Interface;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext :DbContext, IApplicationDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Registration> Register {  get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<SendOTP> sendOTPs { get; set; }
        public DbSet<PaymentGateway> PaymentGateways { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .HasOne(s => s.Country)
                .WithMany(c => c.States)
                .HasForeignKey(s => s.CountryId)
               .OnDelete(DeleteBehavior.Restrict);
              
            modelBuilder.Entity<Login>().HasNoKey();
            base.OnModelCreating(modelBuilder);

        }

        public async Task SaveChangesAsync()
        {
             await base.SaveChangesAsync();
        }
    }
}
