using Easy.Hosts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.Hosts.Core.Persistence.Configuration
{
    public class BookingTypeConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("TB_BOOKING");

            builder.Property(p => p.Id)
                .HasColumnName("BOOKING_ID");
            builder.HasKey(p => p.Id);
        }
    }
}
