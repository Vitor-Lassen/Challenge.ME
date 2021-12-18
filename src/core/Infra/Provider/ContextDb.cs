using Infra.Provider.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Provider
{
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("mem");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemMap).Assembly);
        }
    }
}
