using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Configurations;
using WebApplication1.Models;
using WebApplication1.Models.Base;

namespace WebApplication1
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // new names of Identity tables
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<CustomerVip>();

            // configurations of tables
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ToDoTaskConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new StaffConfiguration());
            builder.ApplyConfiguration(new CustomerVipConfiguration());

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType) &&
                    !typeof(IdentityUser).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.PropertyOrField(parameter, "DeletedAt");
                    var nullConstant = Expression.Constant(null, property.Type);
                    var equality = Expression.Equal(property, nullConstant);
                    var lambda = Expression.Lambda(equality, parameter);

                    builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
                
                if (entityType.FindProperty("DeletedAt") != null)
                {
                    builder.Entity(entityType.ClrType).HasIndex("DeletedAt");
                }
            }


        }

        public override int SaveChanges()
        {
            UpdatedAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdatedAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdatedAuditFields()
        {
            var entries = ChangeTracker.Entries<IAuditableEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.State =  EntityState.Modified;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                }
            }
        }

        //public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubTask> SubTasks{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        //public DbSet<CustomerVip> CustomerVips { get; set; }

    }
}