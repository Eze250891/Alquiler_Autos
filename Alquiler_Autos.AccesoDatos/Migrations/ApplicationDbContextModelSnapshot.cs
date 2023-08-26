﻿// <auto-generated />
using System;
using Alquiler_Autos.Controlador;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alquiler_Autos.AccesoDatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Alquiler_Autos.Entidades.FormaDePago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormaDePagos", (string)null);
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdFormaDePago")
                        .HasColumnType("int");

                    b.Property<int>("IdReserva")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdFormaDePago");

                    b.HasIndex("IdReserva");

                    b.ToTable("Pagos", (string)null);
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdVehiculo")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Reservas", (string)null);
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.TipoCombustible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehiculo", (string)null);
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoriaCarnet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Dni")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimientoCarnet")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("CantidadPasajeros")
                        .HasColumnType("int");

                    b.Property<int>("CantidadPuertas")
                        .HasColumnType("int");

                    b.Property<int?>("CapacidadBault")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadCombustible")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoCombustible")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioAlquilerPorDia")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoCombustible");

                    b.ToTable("Vehiculos", (string)null);
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Pago", b =>
                {
                    b.HasOne("Alquiler_Autos.Entidades.FormaDePago", "FormaDePago")
                        .WithMany("Pagos")
                        .HasForeignKey("IdFormaDePago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alquiler_Autos.Entidades.Reserva", "Reserva")
                        .WithMany("Pagos")
                        .HasForeignKey("IdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormaDePago");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Reserva", b =>
                {
                    b.HasOne("Alquiler_Autos.Entidades.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alquiler_Autos.Entidades.Vehiculo", "Vehiculo")
                        .WithMany("Reservas")
                        .HasForeignKey("IdVehiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Vehiculo", b =>
                {
                    b.HasOne("Alquiler_Autos.Entidades.TipoCombustible", "TiposCombustible")
                        .WithMany("VehiculosList")
                        .HasForeignKey("IdTipoCombustible")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposCombustible");
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.FormaDePago", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Reserva", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.TipoCombustible", b =>
                {
                    b.Navigation("VehiculosList");
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Usuario", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Alquiler_Autos.Entidades.Vehiculo", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
