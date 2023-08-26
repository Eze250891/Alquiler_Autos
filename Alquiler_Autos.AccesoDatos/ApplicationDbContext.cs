using Alquiler_Autos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Alquiler_Autos.Controlador
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<FormaDePago> FormaDePagos { get; set; }
        public DbSet<TipoCombustible> tipoCombustibles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //-----Usuario----
            modelBuilder.Entity<Usuario>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Usuario>()
                        .Property(x => x.Nombre)
                        .IsRequired();

            modelBuilder.Entity<Usuario>()
                        .Property(x => x.Apellido)
                        .IsRequired();

            modelBuilder.Entity<Usuario>()
                        .Property(x => x.FechaNacimiento)
                        .IsRequired();

            modelBuilder.Entity<Usuario>()
                        .Property(x => x.Dni)
                        .HasMaxLength(99_999_999)
                        .IsRequired();

            modelBuilder.Entity<Usuario>()
                        .Property(x => x.Nacionalidad)
                        .HasMaxLength(25)
                        .IsRequired();

            modelBuilder.Entity<Usuario>()
                        .Property(x => x.Telefono)
                        .HasMaxLength(15)
                        .IsRequired();

            modelBuilder.Entity<Usuario>()
                        .Property(x => x.Email)
                        .IsRequired();

            modelBuilder.Entity<Usuario>()
                        .Property(x => x.CategoriaCarnet)
                        .IsRequired();

            modelBuilder.Entity<Usuario>()
                        .Property(x => x.FechaVencimientoCarnet)
                        .IsRequired();

            //-----Vehiculo----
            modelBuilder.Entity<Vehiculo>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Vehiculo>()
                        .Property(x => x.IdTipoCombustible);

            modelBuilder.Entity<Vehiculo>()
                        .Property(x => x.Marca)
                        .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                        .Property(x => x.Modelo)
                        .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                        .Property(x => x.Anio)
                        .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                        .Property(x => x.CantidadPasajeros)
                        .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                        .Property(x => x.CantidadPuertas)
                        .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                        .Property(x => x.CapacidadCombustible)
                        .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                        .Property(x => x.PrecioAlquilerPorDia)
                        .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                        .Property(x => x.CapacidadBault);

            //modelBuilder.Entity<Vehiculo>()
            //            .Property(x => x.Kms)
            //            .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                        .HasOne(c => c.TiposCombustible)
                        .WithMany(t => t.VehiculosList)
                        .HasForeignKey(x => x.IdTipoCombustible);

            //-----Reserva----

            modelBuilder.Entity<Reserva>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Reserva>()
                        .Property(x => x.IdVehiculo);

            modelBuilder.Entity<Reserva>()
                        .Property(x => x.IdUsuario);

            modelBuilder.Entity<Reserva>()
                        .Property(x => x.FechaEntrada)
                        .IsRequired();

            modelBuilder.Entity<Reserva>()
                        .Property(x => x.FechaSalida)
                        .IsRequired();

            modelBuilder.Entity<Reserva>()
                        .Property(x => x.Total)
                         .IsRequired();

            modelBuilder.Entity<Reserva>()
                        .HasOne(r => r.Usuario)
                        .WithMany(u => u.Reservas)
                        .HasForeignKey(x => x.IdUsuario);
            
            modelBuilder.Entity<Reserva>()
                        .HasOne(r => r.Vehiculo)
                        .WithMany(v => v.Reservas)
                        .HasForeignKey(x => x.IdVehiculo);
                        

            //-----Pagos----

            modelBuilder.Entity<Pago>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Pago>()
                        .Property(x => x.IdReserva)
                        .IsRequired();

            modelBuilder.Entity<Pago>()
                        .Property(x => x.IdFormaDePago)
                        .IsRequired();

            modelBuilder.Entity<Pago>()
                        .Property(x => x.Monto)
                        .IsRequired();

            modelBuilder.Entity<Pago>()
                        .HasOne(x => x.FormaDePago)
                        .WithMany(f => f.Pagos)
                        .HasForeignKey(x => x.IdFormaDePago);
            
            modelBuilder.Entity<Pago>()
                        .HasOne(r => r.Reserva)
                        .WithMany(r => r.Pagos)
                        .HasForeignKey(x => x.IdReserva);



            //----FormaDePago----

            modelBuilder.Entity<FormaDePago>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<FormaDePago>()
                        .Property(x => x.Descripcion)
                        .IsRequired();

            //-----TipoDeCombustible----

            modelBuilder.Entity<TipoCombustible>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<TipoCombustible>()
                        .Property(x => x.Descripcion)
                        .IsRequired();


        }
    }
}