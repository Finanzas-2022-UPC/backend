using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(50);

            //Projects
            builder.Entity<Project>().ToTable("Projects");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Project>().Property(p => p.UrlToImage);
            builder.Entity<Project>().HasOne(p => p.User).WithMany(u => u.Projects).IsRequired();


            builder.UseSnakeCaseNamingConvention();

        }
    }
}
