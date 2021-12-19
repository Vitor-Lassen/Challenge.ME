using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Provider.Mapping
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Description);
            builder.Property(b => b.Amount);
            builder.Property(b => b.UnitPrice);
            builder.Property(b => b.OrderId);
            builder.HasOne(o => o.Order)
                   .WithMany(m => m.Items)
                   .HasForeignKey(o => o.OrderId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();

        }
    }
}
