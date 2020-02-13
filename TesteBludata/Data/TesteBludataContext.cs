using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBludata.Models;

namespace TesteBludata.Data
{
    public class TesteBludataContext : DbContext
    {
        public TesteBludataContext (DbContextOptions<TesteBludataContext> options)
            : base(options)
        {
        }

        public DbSet<TesteBludata.Models.Empresa> Empresa { get; set; }
    }
}
