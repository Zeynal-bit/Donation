using Donation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donation.Data
{
    public class PaymentDbContext : DbContext
    {
        public DbSet<PaymentList> PaymentLists { get; set; }

        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
            :base(options)
        {
        }

    }
}
