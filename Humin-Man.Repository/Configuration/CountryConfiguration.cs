using Humin_Man.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Humin_Man.Repository.Configuration
{
    internal class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne<Country>(e => (Country)e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
