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

            builder.Property(p => p.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("UPDATED_AT");

            builder.Property(p => p.TotalValue)
                .HasColumnName("TOTAL_VALUE");

            builder.Property(p => p.Status)
                .HasColumnName("STATUS");

            builder.Property(p => p.BedroomId)
               .HasColumnName("BEDROOM_ID");

            builder.Property(p => p.Checkin)
               .HasColumnName("CHECKIN");

            builder.Property(p => p.Checkout)
               .HasColumnName("CHECKOUT");

            builder.Property(p => p.CodeBooking)
               .HasColumnName("CODE_BOOKING");

            builder.Property(p => p.UserId)
               .HasColumnName("USER_ID");

            builder.HasOne(p => p.User)
                .WithMany(p => p.Booking)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(q => q.Bedroom)
                .WithOne();
        }
    }
}
