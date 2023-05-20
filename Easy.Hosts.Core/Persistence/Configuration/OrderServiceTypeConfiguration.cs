using Easy.Hosts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Easy.Hosts.Core.Persistence.Configuration
{
    public class OrderServiceTypeConfiguration : IEntityTypeConfiguration<OrderService>
    {
        public void Configure(EntityTypeBuilder<OrderService> builder)
        {
            builder.ToTable("TB_ORDER_SERVICE");

            builder.Property(p => p.Id)
                .HasColumnName("ID");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductId)
                .HasColumnName("PRODUCT_ID");

            builder.HasOne(a => a.Product)
                .WithOne(b => b.OrderService)
                .HasForeignKey<Product>(b => b.Id);

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION");

            builder.Property(p => p.EmployeeId)
               .HasColumnName("EMPLOYEE_ID");

            builder.Property(p => p.UserId)
                .HasColumnName("USER_ID");

            builder.Property(p => p.Type)
                .HasColumnName("ORDER_SERVICE_TYPE");

            builder.Property(p => p.Status)
                .HasColumnName("STATUS");

            builder.Property(p => p.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("UPDATED_AT");
        }
    }
}
