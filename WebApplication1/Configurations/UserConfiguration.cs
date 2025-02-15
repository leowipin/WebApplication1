using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            // relationships
            entity.HasOne(user => user.Customer)
                .WithOne(customer => customer.User)
                .HasForeignKey<Customer>(customer => customer.Id)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(user => user.Staff)
                .WithOne(staff => staff.User)
                .HasForeignKey<Staff>(staff => staff.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }   
}