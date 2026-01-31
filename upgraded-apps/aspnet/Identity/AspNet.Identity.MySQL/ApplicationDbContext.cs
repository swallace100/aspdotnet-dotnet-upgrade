using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNet.Identity.MySQL;

public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Map to tables with custom names
        builder.Entity<IdentityUser>().ToTable("users");
        builder.Entity<IdentityRole>().ToTable("roles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("userclaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("userlogins");
        builder.Entity<IdentityUserRole<string>>().ToTable("userroles");
    }
}
