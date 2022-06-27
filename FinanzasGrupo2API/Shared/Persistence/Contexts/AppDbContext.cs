using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.DatasFrances.Domain.Models;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Cruds.Domain.Models;

namespace FinanzasGrupo2API.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Users { get; set; }
        public DbSet<Proyecto> Projects { get; set; }
        public DbSet<Bono> Bonos { get; set; }
        public DbSet<DataFrances> DataFrances { get; set; }
        public DbSet<Crud> Cruds { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Users
            builder.Entity<Usuario>().ToTable("usuarios");
            builder.Entity<Usuario>().HasKey(u => u.id);
            builder.Entity<Usuario>().Property(u => u.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Usuario>().Property(u => u.email).IsRequired().HasMaxLength(50);

            //Projects
            builder.Entity<Proyecto>().ToTable("proyectos");
            builder.Entity<Proyecto>().HasKey(p => p.id);
            builder.Entity<Proyecto>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Proyecto>().Property(p => p.nombre).IsRequired().HasMaxLength(50);
            builder.Entity<Proyecto>().Property(p => p.url_to_image);
            builder.Entity<Proyecto>().HasOne(p => p.usuario).WithMany(u => u.projects).IsRequired();
            builder.Entity<Proyecto>().HasOne(p => p.bono).WithOne(b => b.project).IsRequired().HasForeignKey<Bono>(b => b.id);
            builder.Entity<Proyecto>().HasOne(p => p.data_frances).WithOne(dF => dF.project).IsRequired().HasForeignKey<DataFrances>(dF => dF.id);

            //Bonos
            builder.Entity<Bono>().ToTable("bonos");
            builder.Entity<Bono>().HasKey(b => b.id);
            builder.Entity<Bono>().Property(b => b.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Bono>().Property(b => b.valor_nominal).IsRequired();
            builder.Entity<Bono>().Property(b => b.valor_comercial).IsRequired();
            builder.Entity<Bono>().Property(b => b.tasa_cupon).IsRequired();
            builder.Entity<Bono>().Property(b => b.frecuencia_pago).HasMaxLength(50).IsRequired();
            builder.Entity<Bono>().Property(b => b.metodo_pago).HasMaxLength(50).IsRequired();
            builder.Entity<Bono>().Property(b => b.periodos).IsRequired();
            builder.Entity<Bono>().Property(b => b.tea).IsRequired();
            builder.Entity<Bono>().Property(b => b.prima).IsRequired();
            builder.Entity<Bono>().Property(b => b.estructuracion).IsRequired();
            builder.Entity<Bono>().Property(b => b.colocacion).IsRequired();
            builder.Entity<Bono>().Property(b => b.flotacion).IsRequired();
            builder.Entity<Bono>().Property(b => b.gastos_adicionales).IsRequired();
            builder.Entity<Bono>().Property(b => b.impuesto_renta).IsRequired();
            builder.Entity<Bono>().Property(b => b.moneda).HasMaxLength(50).IsRequired();
            

            //DataFrances
            builder.Entity<DataFrances>().ToTable("data_frances");
            builder.Entity<DataFrances>().HasKey(dF => dF.id);
            builder.Entity<DataFrances>().Property(dF => dF.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<DataFrances>().Property(dF => dF.valor_terreno).IsRequired();
            builder.Entity<DataFrances>().Property(dF => dF.cuota_inicial_p);
            builder.Entity<DataFrances>().Property(dF => dF.cuota_inicial);
            builder.Entity<DataFrances>().Property(dF => dF.tea);
            builder.Entity<DataFrances>().Property(dF => dF.metodo).HasMaxLength(50).IsRequired();
            builder.Entity<DataFrances>().Property(dF => dF.plazo_anhos);
            builder.Entity<DataFrances>().Property(dF => dF.plazo_semestre);
            builder.Entity<DataFrances>().Property(dF => dF.plazo_gracia);
            builder.Entity<DataFrances>().Property(dF => dF.capital);
            builder.Entity<DataFrances>().Property(dF => dF.te_semestral);
            builder.Entity<DataFrances>().Property(dF => dF.credito_capitalizado);
            builder.Entity<DataFrances>().Property(dF => dF.nueva_cuota);
            

            //Cruds
            builder.Entity<Crud>().ToTable("crud");
            builder.Entity<Crud>().HasKey(c => c.id);
            builder.Entity<Crud>().Property(c => c.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Crud>().Property(c => c.nombre).IsRequired().HasMaxLength(50);
            builder.Entity<Crud>().Property(c => c.tipo).IsRequired().HasMaxLength(50);
            builder.Entity<Crud>().HasOne(c => c.project).WithMany(p => p.cruds).IsRequired();

            //Movimientos
            builder.Entity<Movimiento>().ToTable("movimientos");
            builder.Entity<Movimiento>().HasKey(m => m.id);
            builder.Entity<Movimiento>().Property(m => m.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Movimiento>().Property(m => m.nombre).IsRequired().HasMaxLength(50);
            builder.Entity<Movimiento>().Property(m => m.monto).IsRequired().HasMaxLength(50);
            builder.Entity<Movimiento>().Property(m => m.incremento);
            builder.Entity<Movimiento>().Property(m => m.mes_aplicable).IsRequired().HasMaxLength(50);
            builder.Entity<Movimiento>().HasOne(m => m.tipo_movimiento);
            builder.Entity<Movimiento>().HasOne(m => m.crud).WithMany(c => c.movimientos).IsRequired();

            //TipoMovimientos
            builder.Entity<TipoMovimiento>().ToTable("tipo_movimientos");
            builder.Entity<TipoMovimiento>().HasKey(c => c.id);
            builder.Entity<TipoMovimiento>().Property(c => c.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TipoMovimiento>().Property(c => c.tipo).IsRequired().HasMaxLength(50);

            builder.UseSnakeCaseNamingConvention();

        }
    }
}
