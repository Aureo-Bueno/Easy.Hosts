using Easy.Hosts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.Hosts.Core.Persistence.Configuration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TB_PRODUCT");

            builder.Property(p => p.Id)
                .HasColumnName("PRODUCT_ID");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreatedAt)
               .HasColumnName("CREATED_AT");

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("UPDATED_AT");

            builder.Property(p => p.Name)
                .HasColumnName("NAME_PRODUCT");

            builder.Property(p => p.Quatity)
                .HasColumnName("QUANTITY");
        }
    }
}
