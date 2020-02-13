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

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
    }
}
