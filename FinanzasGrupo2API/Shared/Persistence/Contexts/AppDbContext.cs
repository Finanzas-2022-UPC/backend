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
            builder.Entity<Proyecto>().HasOne(p => p.usuario).WithMany(u => u.projects).HasForeignKey(u => u.usuarios_id).IsRequired();

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
            builder.Entity<Bono>().Property(b => b.cavali);
            builder.Entity<Bono>().Property(b => b.gastos_adicionales).IsRequired();
            builder.Entity<Bono>().Property(b => b.inflacion);
            builder.Entity<Bono>().Property(b => b.impuesto_renta).IsRequired();
            builder.Entity<Bono>().Property(b => b.moneda).HasMaxLength(50).IsRequired();
            builder.Entity<Bono>().HasOne(b => b.proyecto).WithOne(p => p.bono).HasForeignKey<Bono>(b => b.proyectos_id).IsRequired();


            //DataFrances
            builder.Entity<DataFrances>().ToTable("data_frances");
            builder.Entity<DataFrances>().HasKey(dF => dF.id);
            builder.Entity<DataFrances>().Property(dF => dF.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<DataFrances>().Property(dF => dF.valor_terreno).IsRequired();
            builder.Entity<DataFrances>().Property(dF => dF.cuota_inicial_p);
            builder.Entity<DataFrances>().Property(dF => dF.cuota_inicial);
            builder.Entity<DataFrances>().Property(dF => dF.tea);
            builder.Entity<DataFrances>().Property(dF => dF.frecuencia_pago);
            builder.Entity<DataFrances>().Property(dF => dF.metodo).HasMaxLength(50).IsRequired();
            builder.Entity<DataFrances>().Property(dF => dF.plazo_anhos);
            builder.Entity<DataFrances>().Property(dF => dF.plazo_semestre);
            builder.Entity<DataFrances>().Property(dF => dF.plazo_gracia);
            builder.Entity<DataFrances>().Property(dF => dF.capital);
            builder.Entity<DataFrances>().Property(dF => dF.te_semestral);
            builder.Entity<DataFrances>().Property(dF => dF.credito_capitalizado);
            builder.Entity<DataFrances>().Property(dF => dF.nuevo_tiempo);
            builder.Entity<DataFrances>().Property(dF => dF.nueva_cuota);
            builder.Entity<DataFrances>().HasOne(dF => dF.proyecto).WithOne(p => p.data_frances).HasForeignKey<DataFrances>(dF => dF.proyectos_id).IsRequired();


            //Cruds
            builder.Entity<Crud>().ToTable("crud");
            builder.Entity<Crud>().HasKey(c => c.id);
            builder.Entity<Crud>().Property(c => c.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Crud>().Property(c => c.nombre).IsRequired().HasMaxLength(50);
            builder.Entity<Crud>().Property(c => c.tipo).IsRequired().HasMaxLength(50);
            builder.Entity<Crud>().HasOne(c => c.proyecto).WithMany(p => p.cruds).HasForeignKey(c => c.proyectos_id).IsRequired();

            //Movimientos
            builder.Entity<Movimiento>().ToTable("movimientos");
            builder.Entity<Movimiento>().HasKey(m => m.id);
            builder.Entity<Movimiento>().Property(m => m.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Movimiento>().Property(m => m.nombre).IsRequired().HasMaxLength(50);
            builder.Entity<Movimiento>().Property(m => m.monto).IsRequired().HasMaxLength(50);
            builder.Entity<Movimiento>().Property(m => m.incremento);
            builder.Entity<Movimiento>().Property(m => m.mes_aplicable).IsRequired().HasMaxLength(50);
            builder.Entity<Movimiento>().HasOne(m => m.tipo_movimiento).WithMany(tp => tp.movimientos).HasForeignKey(m => m.tipo_movimientos_id).IsRequired();
            builder.Entity<Movimiento>().HasOne(m => m.crud).WithMany(c => c.movimientos).HasForeignKey(m => m.crud_id).IsRequired();

            //TipoMovimientos
            builder.Entity<TipoMovimiento>().ToTable("tipo_movimientos");
            builder.Entity<TipoMovimiento>().HasKey(c => c.id);
            builder.Entity<TipoMovimiento>().Property(c => c.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TipoMovimiento>().Property(c => c.tipo).IsRequired().HasMaxLength(50);

            builder.UseSnakeCaseNamingConvention();

            var admin = new Usuario();
            admin.email = "admin";
            admin.id = 1;
            admin.nombre = "admin";
            admin.password_hash = "$2a$11$2wGefJjipdjfwx2SjfwfBuruAYqDw9j/gQhxb.B3UTy5XZp2uJqZy";
            builder.Entity<Usuario>().HasData(admin);

            var proyectoTest = new Proyecto();
            proyectoTest.id = 1;
            proyectoTest.usuarios_id = 1;
            proyectoTest.nombre = "Proyecto Test";
            proyectoTest.url_to_image = "https://www.sesametime.com/assets/wp-content/uploads/2020/02/plantilla-para-hoja-de-proyecto.jpg";
            builder.Entity<Proyecto>().HasData(proyectoTest);

            var tipoMovimiento = new TipoMovimiento();
            tipoMovimiento.id = 1;
            tipoMovimiento.tipo = "inversion";
            builder.Entity<TipoMovimiento>().HasData(tipoMovimiento);

            tipoMovimiento = new TipoMovimiento();
            tipoMovimiento.id = 2;
            tipoMovimiento.tipo = "ingreso";
            builder.Entity<TipoMovimiento>().HasData(tipoMovimiento);

            tipoMovimiento = new TipoMovimiento();
            tipoMovimiento.id = 3;
            tipoMovimiento.tipo = "egreso";
            builder.Entity<TipoMovimiento>().HasData(tipoMovimiento);

            var crud = new Crud();
            crud.id = 1;
            crud.nombre = "van";
            crud.proyectos_id = 1;
            crud.tipo = "1";
            builder.Entity<Crud>().HasData(crud);

            crud = new Crud();
            crud.id = 2;
            crud.nombre = "vac1";
            crud.proyectos_id = 1;
            crud.tipo = "2";
            builder.Entity<Crud>().HasData(crud);

            crud = new Crud();
            crud.id = 3;
            crud.nombre = "vac2";
            crud.proyectos_id = 1;
            crud.tipo = "3";
            builder.Entity<Crud>().HasData(crud);

            var movimiento = new Movimiento();
            movimiento.id = 1;
            movimiento.tipo_movimientos_id = 1;
            movimiento.crud_id = 1;
            movimiento.monto = "342";
            movimiento.mes_aplicable = "-1";
            movimiento.nombre = "Depósito";
            builder.Entity<Movimiento>().HasData(movimiento);
        }
    }
}
