using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExempEAP.Entity;

namespace ExempEAP.Models
{
    public class ExempEAPContext : DbContext
    {
        public ExempEAPContext (DbContextOptions<ExempEAPContext> options)
            : base(options)
        {
        }

        public DbSet<ExempEAP.Entity.CurrencyEx> CurrencyEx { get; set; }
    }
}
