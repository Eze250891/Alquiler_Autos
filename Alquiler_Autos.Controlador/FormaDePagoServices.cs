using Alquiler_Autos.Controlador.DTOs.FormaDePago;
using Alquiler_Autos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador
{
    public class FormaDePagoServices : IFormaDePagoServices
    {
        private readonly ApplicationDbContext _context;

        public FormaDePagoServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormaDePagoDetalleDto>> ObtenerTodos()
        {
            var FormasDePago = await _context.FormaDePagos.Select(fm => new FormaDePagoDetalleDto
            {
                Id = fm.Id,
                Descripcion = fm.Descripcion
            }).ToListAsync();

            return FormasDePago;
        }

        public async Task<FormaDePagoDetalleDto> ObtenerPorId(int id)
        {
            FormaDePago? FormaDePago = await BuscarPorId(id);

            return new FormaDePagoDetalleDto
            {
                Id = FormaDePago.Id,
                Descripcion = FormaDePago.Descripcion,
            };
        }

        public async Task<FormaDePagoDetalleDto> Crear(FormaDePagoCrearDto dto)
        {
            var formaDePago = new FormaDePago
            {
                Descripcion = dto.Descripcion,
            };

            var FormaDePagoRepetida = await _context.FormaDePagos.AnyAsync(x => x.Descripcion.ToLower() == dto.Descripcion.ToLower());
            if (FormaDePagoRepetida)
            {
                throw new Exception($"Ya existe");
            }
            await _context.AddAsync(formaDePago);
            await _context.SaveChangesAsync();

            return new FormaDePagoDetalleDto
            {
                Id = formaDePago.Id,
                Descripcion = dto.Descripcion,
            };

        }

        public async Task<FormaDePagoDetalleDto> Actualizar(int id, FormaDePagoCrearDto dto)
        {
            var FormaDePago = await BuscarPorId(id);

            FormaDePago.Descripcion = dto.Descripcion;

            var ActuaizarFormaDePago = await _context.FormaDePagos.AnyAsync(x => x.Descripcion == dto.Descripcion && x.Id != id);

            if(ActuaizarFormaDePago)
            {
                throw new Exception($"La forma de pago {FormaDePago.Descripcion} ya existe");
            }


            _context.Update(FormaDePago);
            await _context.SaveChangesAsync();

            return new FormaDePagoDetalleDto
            {
                Id = FormaDePago.Id,
                Descripcion = FormaDePago.Descripcion
            };
        }

        public async Task<FormaDePagoDetalleDto> Remover(int id)
        {
            var FormaDePago = await BuscarPorId(id);
            _context.Remove(FormaDePago);
            await _context.SaveChangesAsync();

            return new FormaDePagoDetalleDto
            {
                Id = FormaDePago.Id,
                Descripcion = FormaDePago.Descripcion,
            };
        }


        private async Task<FormaDePago?> BuscarPorId(int id)
        {
            var FormaDePago = await _context.FormaDePagos.FindAsync(id);

            if (FormaDePago == null)
            {
                throw new Exception($"La forma de pago con el id {id} no existe");
            }

            return FormaDePago;
        }
    }
}
