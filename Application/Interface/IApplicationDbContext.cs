using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IApplicationDbContext
    {
        public DbSet<Registration> Register { get; }
        public DbSet<Login> Login { get; }
        public DbSet<Product> Products { get; }
        public DbSet<State> States { get; }
        public DbSet<Country> Countries { get; }
        public DbSet<SendOTP> sendOTPs { get; }
        public DbSet<PaymentGateway> PaymentGateways { get; }

        Task SaveChangesAsync();
    }
}
