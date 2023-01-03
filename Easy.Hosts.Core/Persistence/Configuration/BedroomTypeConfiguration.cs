using Easy.Hosts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.Hosts.Core.Persistence.Configuration
{
    public class BedroomTypeConfiguration : IEntityTypeConfiguration<Bedroom>
    {
        public void Configure(EntityTypeBuilder<Bedroom> builder)
        {
            builder.ToTable("TB_BEDROOM");

            builder.Property(p => p.Id)
                .HasColumnName("BEDROOM_ID");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnName("NAME");

            builder.Property(p => p.Number)
                .HasColumnName("NUMBER");
        }
    }
}
