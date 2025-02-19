using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class CustomerVipConfiguration : IEntityTypeConfiguration<CustomerVip>
    {
        public void Configure(EntityTypeBuilder<CustomerVip> entity)
        {
            // properties
            entity.Property(x => x.Discount).HasColumnType("decimal(3,2)");
        }
    }
}