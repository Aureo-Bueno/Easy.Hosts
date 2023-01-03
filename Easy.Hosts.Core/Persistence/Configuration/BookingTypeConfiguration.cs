using Easy.Hosts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
