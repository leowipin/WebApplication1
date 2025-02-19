using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Enums;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            // to table
            entity.ToTable("Customers", b =>
            {
                b.HasCheckConstraint("CK_CustomerType", $"[CustomerType] IN ('{nameof(CustomerTypes.Regular)}', '{nameof(CustomerTypes.VIP)}')");
            });

            // properties
            entity.Property(x => x.CustomerType).HasConversion<string>().HasDefaultValue(CustomerTypes.Regular);
            
            // relationships
            entity.HasMany(cust => cust.Comments)
                .WithOne(comm => comm.Customer)
                .HasForeignKey(comm => comm.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            // discriminators
            entity.HasDiscriminator(x => x.CustomerType)
              .HasValue<Customer>(CustomerTypes.Regular)
              .HasValue<CustomerVip>(CustomerTypes.VIP);
        }
    }
}