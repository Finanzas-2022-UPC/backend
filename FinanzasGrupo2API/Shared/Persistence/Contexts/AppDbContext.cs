using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.DataFrancess.Domain.Models;

namespace FinanzasGrupo2API.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Bono> Bonos { get; set; }
        public DbSet<DataFrances> DataFrances { get; set; }
        
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

            //Bonos
            builder.Entity<Bono>().ToTable("Bonos");
            builder.Entity<Bono>().HasKey(b => b.Id);
            builder.Entity<Bono>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Bono>().Property(b => b.ValorNominal).IsRequired();
            builder.Entity<Bono>().Property(b => b.ValorComercial).IsRequired();
            builder.Entity<Bono>().Property(b => b.TasaCupon).IsRequired();
            builder.Entity<Bono>().Property(b => b.FrecuenciaPago).HasMaxLength(50).IsRequired();
            builder.Entity<Bono>().Property(b => b.MetodoPago).HasMaxLength(50).IsRequired();
            builder.Entity<Bono>().Property(b => b.Periodos).IsRequired();
            builder.Entity<Bono>().Property(b => b.TEA).IsRequired();
            builder.Entity<Bono>().Property(b => b.Prima).IsRequired();
            builder.Entity<Bono>().Property(b => b.Estructuracion).IsRequired();
            builder.Entity<Bono>().Property(b => b.Colocacion).IsRequired();
            builder.Entity<Bono>().Property(b => b.Flotacion).IsRequired();
            builder.Entity<Bono>().Property(b => b.GastosAdicionales).IsRequired();
            builder.Entity<Bono>().Property(b => b.ImpuestoRenta).IsRequired();
            builder.Entity<Bono>().Property(b => b.Moneda).HasMaxLength(50).IsRequired();
            builder.Entity<Bono>().HasOne(b => b.Project).WithOne(u => u.Bono).IsRequired().HasForeignKey<Project>(p => p.Id);

            //DataFrances
            builder.Entity<DataFrances>().ToTable("DataFrances");
            builder.Entity<DataFrances>().HasKey(dF => dF.Id);
            builder.Entity<DataFrances>().Property(dF => dF.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<DataFrances>().Property(dF => dF.ValorTerreno).IsRequired();
            builder.Entity<DataFrances>().Property(dF => dF.CuotaInicialP);
            builder.Entity<DataFrances>().Property(dF => dF.CuotaInicial);
            builder.Entity<DataFrances>().Property(dF => dF.TEA);
            builder.Entity<DataFrances>().Property(dF => dF.Metodo).HasMaxLength(50).IsRequired();
            builder.Entity<DataFrances>().Property(dF => dF.PlazoAnhos);
            builder.Entity<DataFrances>().Property(dF => dF.PlazoSemestre);
            builder.Entity<DataFrances>().Property(dF => dF.PlazoGracia);
            builder.Entity<DataFrances>().Property(dF => dF.Capital);
            builder.Entity<DataFrances>().Property(dF => dF.TeSemestral);
            builder.Entity<DataFrances>().Property(dF => dF.CreditoCapitalizado);
            builder.Entity<DataFrances>().Property(dF => dF.NuevaCuota);
            builder.Entity<DataFrances>().HasOne(dF => dF.Project).WithOne(u => u.DataFrances).IsRequired().HasForeignKey<Project>(p => p.Id);

            builder.UseSnakeCaseNamingConvention();

        }
    }
}
