using Alquiler_Autos.Controlador.DTOs.Pago;
using Alquiler_Autos.Controlador.DTOs.Reserva;
using Alquiler_Autos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador
{
    public class PagoServices : IPagoServices
    {
        private readonly ApplicationDbContext _context;

        public PagoServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PagoDetalleDto>> ObtenerTodos()
        {
            var pagos = await _context.Pagos.Select(p => new PagoDetalleDto
            {
                Id = p.Id,
                IdReserva = p.IdReserva,
                IdFormaDePago = p.IdFormaDePago,
                Monto = p.Monto,
            }).ToListAsync();
            return pagos;
        }

        public async Task<PagoDetalleDto> ObtenerPorId(int id)
        {
            var pago = await BuscarPorId(id);

            return new PagoDetalleDto
            {
                Id = pago.Id,
                IdReserva = pago.IdReserva,
                IdFormaDePago = pago.IdFormaDePago,
                Monto = pago.Monto,
            };
        }

        public async Task<PagoDetalleDto> Crear(PagoCrearDto dto)
        {
            var reserva = await _context.Reservas.FindAsync(dto.IdReserva);

            var pago = new Pago
            {
                IdReserva = dto.IdReserva,
                IdFormaDePago = dto.IdFormaDePago,
                Monto = dto.Monto,
            };

            await _context.AddAsync(pago);
            //await _context.SaveChangesAsync();

            return new PagoDetalleDto
            {
                IdReserva = dto.IdReserva,
                IdFormaDePago = dto.IdFormaDePago,
                Monto = dto.Monto,
            };

        }

        public async Task<PagoDetalleDto> Actualizar(int id, PagoCrearDto dto)
        {
            var pago = await BuscarPorId(id);
            pago.IdReserva = dto.IdReserva;
            pago.IdFormaDePago = dto.IdFormaDePago;
            pago.Monto = dto.Monto;

            _context.Update(pago);
            await _context.SaveChangesAsync();

            return new PagoDetalleDto
            {
                IdReserva = pago.IdReserva,
                IdFormaDePago = pago.IdFormaDePago,
                Monto = pago.Monto,
            };
        }

        public async Task<PagoDetalleDto> Remover(int id)
        {
            var pago = await BuscarPorId(id);
            _context.Remove(pago);
            await _context.SaveChangesAsync();

            return new PagoDetalleDto
            {
                IdReserva = pago.IdReserva,
                IdFormaDePago = pago.IdFormaDePago,
                Monto = pago.Monto,
            };
        }

        private async Task<Pago> BuscarPorId(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
            {
                throw new Exception($"El pago con el id {id} no existe");
            }

            return pago;
        }
    }
}
