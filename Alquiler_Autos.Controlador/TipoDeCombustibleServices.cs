using Alquiler_Autos.Controlador.DTOs.FormaDePago;
using Alquiler_Autos.Controlador.DTOs.TipoDeCombustible;
using Alquiler_Autos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador
{
    public class TipoDeCombustibleServices : ITipoDeCombustibleServices
    {
        private readonly ApplicationDbContext _context;

        public TipoDeCombustibleServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoDeCombustibleDetalleDto>> ObtenerTodos()
        {
            var tipoDeCombustibles = await _context.tipoCombustibles.Select(c => new TipoDeCombustibleDetalleDto
            {
                Id = c.Id,
                Descripcion = c.Descripcion
            }).ToListAsync();

            return tipoDeCombustibles;
        }

        public async Task<TipoDeCombustibleDetalleDto> ObtenerPorId(int id)
        {
            var tipoDecombustible = await BuscarPorId(id);

            return new TipoDeCombustibleDetalleDto
            {
                Id = tipoDecombustible.Id,
                Descripcion = tipoDecombustible.Descripcion,
            };
        }

        public async Task<TipoDeCombustibleDetalleDto> Crear(TipoDeCombustibleCrearDto dto)
        {
            var combustible = new TipoCombustible
            {
                Descripcion = dto.Descripcion,
            };

            var combustibleRepetido = await _context.tipoCombustibles.AnyAsync(x => x.Descripcion.ToLower() == dto.Descripcion.ToLower());
            if (combustibleRepetido)
            {
                throw new Exception($"Ya existe");
            }
            await _context.AddAsync(combustible);
            await _context.SaveChangesAsync();

            return new TipoDeCombustibleDetalleDto
            {
                Id = combustible.Id,
                Descripcion = combustible.Descripcion,
            };

        }

        public async Task<TipoDeCombustibleDetalleDto> Actualizar(int id, TipoDeCombustibleCrearDto dto)
        {
            var combustible = await BuscarPorId(id);

            combustible.Descripcion = dto.Descripcion;

            var actuaizarTipoDeCombustible = await _context.tipoCombustibles.AnyAsync(x => x.Descripcion == dto.Descripcion && x.Id != id);

            if (actuaizarTipoDeCombustible)
            {
                throw new Exception($"El combustible {combustible.Descripcion} ya existe");
            }


            _context.Update(combustible);
            await _context.SaveChangesAsync();

            return new TipoDeCombustibleDetalleDto
            {
                Id = combustible.Id,
                Descripcion = combustible.Descripcion
            };
        }

        public async Task<TipoDeCombustibleDetalleDto> Remover(int id)
        {
            var combustible = await BuscarPorId(id);
            _context.Remove(combustible);
            await _context.SaveChangesAsync();

            return new TipoDeCombustibleDetalleDto
            {
                Id = combustible.Id,
                Descripcion = combustible.Descripcion,
            };
        }

        private async Task<TipoCombustible?> BuscarPorId(int id)
        {
            var combustible = await _context.tipoCombustibles.FindAsync(id);

            if (combustible == null)
            {
                throw new Exception($"La combustible con el id {id} no existe");
            }

            return combustible;
        }
    }
}
