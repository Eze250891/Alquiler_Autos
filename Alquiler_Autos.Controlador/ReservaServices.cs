using Alquiler_Autos.Controlador.DTOs.Reserva;
using Alquiler_Autos.Controlador.DTOs.Usuario;
using Alquiler_Autos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador
{
    public class ReservaServices : IReservaServices
    {
        private readonly ApplicationDbContext _context;

        public ReservaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReservaDetalleDto>> ObtenerTodos()
        {
            var reserva = await _context.Reservas.Select(r => new ReservaDetalleDto
            {
                Id = r.Id,
                IdVehiculo = r.IdVehiculo,
                IdUsuario = r.IdUsuario,
                FechaEntrada = r.FechaEntrada,
                FechaSalida = r.FechaSalida,
                Total = r.Total,
            }).ToListAsync();

            return reserva;
        }

        public async Task<ReservaDetalleDto> ObtenerPorId(int id)
        {
            var reserva = await BuscarPorId(id);

            return new ReservaDetalleDto
            {
                Id = reserva.Id,
                IdVehiculo = reserva.IdVehiculo,
                IdUsuario = reserva.IdUsuario,
                FechaEntrada = reserva.FechaEntrada,
                FechaSalida = reserva.FechaSalida,
                Total = reserva.Total,
            };
        }

        public async Task<ReservaDetalleDto> Crear(ReservaCrearDto dto)
        {
            //validar que el usuario exista 

            var usuarioExistente = await _context.Usuarios.AnyAsync(x => x.Id == dto.IdUsuario);

            if (!usuarioExistente)
            {
                throw new Exception($"El usuario con el id {dto.IdUsuario} ya existe");
            }

            //que el vehiculo exista

            var vehiculoExistente = await _context.Vehiculos.AnyAsync(v => v.Id == dto.IdVehiculo);

            if (!vehiculoExistente)
            {
                throw new Exception($"El vehiculo con el id {dto.IdVehiculo} ya existe Capo");
            }

            //validar disponibilidad en la fecha de reserva, mayor a fecha de salida y menor a la de entrada

            var fechaDisponible = await _context.Reservas.AnyAsync(x => x.IdVehiculo == dto.IdVehiculo &&
                                                                       (dto.FechaEntrada >= x.FechaEntrada && dto.FechaEntrada <= x.FechaSalida ||
                                                                       dto.FechaSalida >= x.FechaEntrada && dto.FechaSalida <= x.FechaSalida));
            if (!fechaDisponible)
            {
                throw new Exception($"La fecha elegida no esta disponible");
            }

            //validar que el usuario no tenga reserva dentro de la fecha de reserva

            var usuarioReserva = await _context.Reservas.AnyAsync(x => x.IdUsuario == dto.IdUsuario &&
                                                                       (dto.FechaEntrada >= x.FechaEntrada && dto.FechaEntrada <= x.FechaSalida ||
                                                                       dto.FechaSalida >= x.FechaEntrada && dto.FechaSalida <= x.FechaSalida));

            if (!usuarioReserva)
            {
                throw new Exception($"El usuario ya tiene una reserva en esa fecha");
            }


            //calcular total de la reserva, teniendo en cuenta dias y valor del vehiculo

            var vehiculo = await _context.Vehiculos.FindAsync(dto.IdVehiculo);

            var resultado = dto.FechaSalida - dto.FechaEntrada;

            var total = resultado.Days * vehiculo.PrecioAlquilerPorDia;

            //que el usuario no tenga carnet vencido

            var usuarioConCarnetVencido = await _context.Usuarios.AnyAsync(x => x.Id == dto.IdUsuario && x.FechaVencimientoCarnet < DateTime.Now);
            
            if (usuarioConCarnetVencido)
            {
                throw new Exception("el usuario tiene el carnet vencido");
            }
            //----------------------------------------
            var reserva = new Reserva
            {
                IdUsuario = dto.IdUsuario,
                IdVehiculo = dto.IdVehiculo,
                FechaEntrada = dto.FechaEntrada,
                FechaSalida = dto.FechaSalida,
               Total = total,
            };

            await _context.AddAsync(reserva);
            await _context.SaveChangesAsync();

            return new ReservaDetalleDto
            {
                IdUsuario = dto.IdUsuario,
                IdVehiculo = dto.IdVehiculo,
                FechaEntrada = dto.FechaEntrada,
                FechaSalida = dto.FechaSalida,
            };

        }

        public async Task<ReservaDetalleDto> Actualizar(int id, ReservaCrearDto dto)
        {
            var reserva = await BuscarPorId(id);
            reserva.IdUsuario = dto.IdUsuario;
            reserva.IdVehiculo = dto.IdVehiculo;
            reserva.FechaEntrada = dto.FechaEntrada;
            reserva.FechaSalida = dto.FechaSalida;
           

            _context.Update(reserva);
            await _context.SaveChangesAsync();

            return new ReservaDetalleDto
            {
                IdUsuario = reserva.IdUsuario,
                IdVehiculo = reserva.IdVehiculo,
                FechaEntrada = reserva.FechaEntrada,
                FechaSalida = reserva.FechaSalida,
                Total = reserva.Total,
            };
        }

        public async Task<ReservaDetalleDto> Remover(int id)
        {
            var reserva = await BuscarPorId(id);
            _context.Remove(reserva);
            await _context.SaveChangesAsync();

            return new ReservaDetalleDto
            {
                IdUsuario = reserva.IdUsuario,
                IdVehiculo = reserva.IdVehiculo,
                FechaEntrada = reserva.FechaEntrada,
                FechaSalida = reserva.FechaSalida,
                Total = reserva.Total,
            };
        }

        private async Task<Reserva> BuscarPorId(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                throw new Exception($"La reserva con el id {id} no existe");
            }

            return reserva;
        }

    }
}
