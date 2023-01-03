using Easy.Hosts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.Hosts.Core.Persistence.Configuration
{
    public class TypeBedroomTypeConfiguration : IEntityTypeConfiguration<TypeBedroom>
    {
        public void Configure(EntityTypeBuilder<TypeBedroom> builder)
        {
            builder.ToTable("TB_TYPE_BEDROOM");

            builder.Property(p => p.Id)
                .HasColumnName("TYPE_BEDROOM_ID");

            builder.HasKey(p => p.Id);
        }
    }
}
