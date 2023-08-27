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
            var reserva = new Reserva
            {
                IdUsuario = dto.IdUsuario,
                IdVehiculo = dto.IdVehiculo,
                FechaEntrada = dto.FechaEntrada,
                FechaSalida = dto.FechaSalida,
                Total = dto.Total,

            };

            var usuarioRepetido = await _context.Reservas.AnyAsync(x => x.IdUsuario == dto.IdUsuario);
            if (usuarioRepetido)
            {
                throw new Exception($"Ya existe usuario para esa reserva {dto.IdVehiculo}");
            }

            var vehiculoRepetido = await _context.Reservas.AnyAsync(x => x.IdVehiculo == dto.IdVehiculo);
            if (vehiculoRepetido)
            {
                throw new Exception($"Ya existe una reserva con ese vehiculo {dto.IdVehiculo}");
            }


            await _context.AddAsync(reserva);
            await _context.SaveChangesAsync();

            return new ReservaDetalleDto
            {
                IdUsuario = dto.IdUsuario,
                IdVehiculo = dto.IdVehiculo,
                FechaEntrada = dto.FechaEntrada,
                FechaSalida = dto.FechaSalida,
                Total = dto.Total,
            };

        }

        public async Task<ReservaDetalleDto> Actualizar(int id, ReservaCrearDto dto)
        {
            var reserva = await BuscarPorId(id);
            reserva.IdUsuario = dto.IdUsuario;
            reserva.IdVehiculo = dto.IdVehiculo;
            reserva.FechaEntrada = dto.FechaEntrada;
            reserva.FechaSalida = dto.FechaSalida;
            reserva.Total = dto.Total;

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
