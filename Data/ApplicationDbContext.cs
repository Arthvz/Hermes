using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Hermes.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Renomeia a tabela AspNetUsers para User
        builder.Entity<ApplicationUser>(b =>
        {
            b.ToTable("User");
        });
    }

    public DbSet<News> News { get; set; }
    public new DbSet<User> Users { get; set; }
}