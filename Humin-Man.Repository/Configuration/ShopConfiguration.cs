using Humin_Man.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Humin_Man.Repository.Configuration
{
    internal class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne<Shop>(e => (Shop)e.Shop)
                .WithMany()
                .HasForeignKey(e => e.ShopId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
