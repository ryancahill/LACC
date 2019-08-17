using LACC.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LACC.Data
{
    public class LACCDbContext : DbContext
    {
        public LACCDbContext(DbContextOptions<LACCDbContext> options) : base(options)
        {

        }

        public DbSet<Cigar> Cigars { get; set; }

    }
}
