using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("Customers");
            // relationships
            entity.HasMany(cust => cust.Comments)
                .WithOne(comm => comm.Customer)
                .HasForeignKey(comm => comm.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}