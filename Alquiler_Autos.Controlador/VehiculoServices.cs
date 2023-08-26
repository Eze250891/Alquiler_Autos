using Alquiler_Autos.Controlador.DTOs.TipoDeCombustible;
using Alquiler_Autos.Controlador.DTOs.Vehiculo;
using Alquiler_Autos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador
{
    public class VehiculoServices : IVehiculoServices
    {
        private readonly ApplicationDbContext _context;

        public VehiculoServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VehiculoDetalleDto>> ObtenerTodos()
        {
            var vehiculo = await _context.Vehiculos.Select(v => new VehiculoDetalleDto
            {
                Id = v.Id,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Anio = v.Anio,
                IdTipoCombustible = v.IdTipoCombustible,
                CantidadPasajeros = v.CantidadPasajeros,
                CantidadPuertas = v.CantidadPuertas,
                CapacidadCombustible = v.CapacidadCombustible,
                CapacidadBault = v.CapacidadBault,
                PrecioAlquilerPorDia = v.PrecioAlquilerPorDia
            }).ToListAsync();

            return vehiculo;
        }

        public async Task<VehiculoDetalleDto> ObtenerPorId(int id)
        {
            var vehiculo = await BuscarPorId(id);

            return new VehiculoDetalleDto
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = vehiculo.Anio,
                IdTipoCombustible = vehiculo.IdTipoCombustible,
                CantidadPasajeros = vehiculo.CantidadPasajeros,
                CantidadPuertas = vehiculo.CantidadPuertas,
                CapacidadCombustible = vehiculo.CapacidadCombustible,
                CapacidadBault = vehiculo.CapacidadBault,
                PrecioAlquilerPorDia = vehiculo.PrecioAlquilerPorDia
            };
        }

        public async Task<VehiculoDetalleDto> Crear(VehiculoCrearDto dto)
        {
            var vehiculo = new Vehiculo
            {
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Anio = dto.Anio,
                IdTipoCombustible = dto.IdTipoCombustible,
                CantidadPasajeros = dto.CantidadPasajeros,
                CantidadPuertas = dto.CantidadPuertas,
                CapacidadCombustible = dto.CapacidadCombustible,
                CapacidadBault = dto.CapacidadBault,
                PrecioAlquilerPorDia = dto.PrecioAlquilerPorDia
            };

            await _context.AddAsync(vehiculo);
            await _context.SaveChangesAsync();

            return new VehiculoDetalleDto
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = vehiculo.Anio,
                IdTipoCombustible = vehiculo.IdTipoCombustible,
                CantidadPasajeros = vehiculo.CantidadPasajeros,
                CantidadPuertas = vehiculo.CantidadPuertas,
                CapacidadCombustible = vehiculo.CapacidadCombustible,
                CapacidadBault = vehiculo.CapacidadBault,
                PrecioAlquilerPorDia = vehiculo.PrecioAlquilerPorDia
            };

        }

        public async Task<VehiculoDetalleDto> Actualizar(int id, VehiculoCrearDto dto)
        {
            var vehiculo = await BuscarPorId(id);

            vehiculo.Marca = dto.Marca;
            vehiculo.Modelo = dto.Modelo;
            vehiculo.Anio = dto.Anio;
            vehiculo.IdTipoCombustible = dto.IdTipoCombustible;
            vehiculo.CantidadPasajeros = dto.CantidadPasajeros;
            vehiculo.CantidadPuertas = dto.CantidadPuertas;
            vehiculo.CapacidadCombustible = dto.CapacidadCombustible;
            vehiculo.CapacidadBault = dto.CapacidadBault;
            vehiculo.PrecioAlquilerPorDia = dto.PrecioAlquilerPorDia;

            _context.Update(vehiculo);
            await _context.SaveChangesAsync();

            return new VehiculoDetalleDto
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = vehiculo.Anio,
                IdTipoCombustible = vehiculo.IdTipoCombustible,
                CantidadPasajeros = vehiculo.CantidadPasajeros,
                CantidadPuertas = vehiculo.CantidadPuertas,
                CapacidadCombustible = vehiculo.CapacidadCombustible,
                CapacidadBault = vehiculo.CapacidadBault,
                PrecioAlquilerPorDia = vehiculo.PrecioAlquilerPorDia
            };
        }

        public async Task<VehiculoDetalleDto> Remover(int id)
        {
            var vehiculo = await BuscarPorId(id);
            _context.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return new VehiculoDetalleDto
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = vehiculo.Anio,
                IdTipoCombustible = vehiculo.IdTipoCombustible,
                CantidadPasajeros = vehiculo.CantidadPasajeros,
                CantidadPuertas = vehiculo.CantidadPuertas,
                CapacidadCombustible = vehiculo.CapacidadCombustible,
                CapacidadBault = vehiculo.CapacidadBault,
                PrecioAlquilerPorDia = vehiculo.PrecioAlquilerPorDia
            };
        }

        private async Task<Vehiculo?> BuscarPorId(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                throw new Exception($"El vehiculo con el id {id} no existe");
            }

            return vehiculo;
        }
    }
}
    