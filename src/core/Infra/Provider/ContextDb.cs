using Infra.Provider.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Infra.Provider
{
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.LogTo(Console.WriteLine);
                optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB; Database = db_lassen; Trusted_Connection = True; ");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemMap).Assembly);
        }
    }
}
