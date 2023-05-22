using Easy.Hosts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.Hosts.Core.Persistence.Configuration
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("TB_EVENT");

            builder.Property(p => p.Id)
                .HasColumnName("EVENT_ID");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreatedAt)
               .HasColumnName("CREATED_AT");

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("UPDATED_AT");
        }
    }
}
