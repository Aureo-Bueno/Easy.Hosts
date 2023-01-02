using Easy.Hosts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.Hosts.Core.Persistence.Configuration
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USER");

            builder.Property(p => p.Id)
                .HasColumnName("USER_ID");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnName("NAME");

            builder.Property(p => p.Email)
                .HasColumnName("EMAIL");

            builder.Property(p => p.Password)
               .HasColumnName("PASSWORD");
        }
    }
}
