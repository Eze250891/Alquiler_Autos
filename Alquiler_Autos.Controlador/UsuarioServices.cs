
using Alquiler_Autos.Controlador.DTOs.Usuario;
using Alquiler_Autos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioDetalleDto>> ObtenerTodos()
        {
            var usuarios = await _context.Usuarios.Select(u => new UsuarioDetalleDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                FechaNacimiento = u.FechaNacimiento,
                Dni = u.Dni,
                Nacionalidad = u.Nacionalidad,
                Telefono = u.Telefono,
                Email = u.Email,
                CategoriaCarnet = u.CategoriaCarnet,
                FechaVencimientoCarnet = u.FechaVencimientoCarnet
            }).ToListAsync();

            return usuarios;
        }

        public async Task<UsuarioDetalleDto> ObtenerPorId(int id)
        {
            var usuario = await BuscarPorId(id);

            return new UsuarioDetalleDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                Dni = usuario.Dni,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                CategoriaCarnet = usuario.CategoriaCarnet,
                FechaVencimientoCarnet = usuario.FechaVencimientoCarnet
            };
        }

        public async Task<UsuarioDetalleDto> Crear(UsuarioCrearDto dto)
        {
            var dniRepetido = await _context.Usuarios.AnyAsync(x => x.Dni == dto.Dni);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un usuario con ese dni {dto.Dni}");
            }

            var emailRepetido = await _context.Usuarios.AnyAsync(x => x.Email == dto.Email);
            if (emailRepetido)
            {
                throw new Exception($"Ya existe ese {dto.Email}");
            }


            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                FechaNacimiento = dto.FechaNacimiento,
                Dni = dto.Dni,
                Nacionalidad = dto.Nacionalidad,
                Telefono = dto.Telefono,
                Email = dto.Email,
                CategoriaCarnet = dto.CategoriaCarnet,
                FechaVencimientoCarnet = dto.FechaVencimientoCarnet
            };

           
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioDetalleDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                Dni = usuario.Dni,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                CategoriaCarnet = usuario.CategoriaCarnet,
                FechaVencimientoCarnet = usuario.FechaVencimientoCarnet
            };

        }

        public async Task<UsuarioDetalleDto> Actualizar(int id, UsuarioCrearDto dto)
        {
            var dniRepetido = await _context.Usuarios.AnyAsync(x => x.Dni == dto.Dni && id != x.Id);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un usuario con ese dni {dto.Dni}");
            }

            var emailRepetido = await _context.Usuarios.AnyAsync(x => x.Email == dto.Email);
            if (emailRepetido)
            {
                throw new Exception($"Ya existe ese {dto.Email}");
            }

            var telefonoRepetido = await _context.Usuarios.AnyAsync(x => x.Telefono == dto.Telefono);
            if (telefonoRepetido)
            {
                throw new Exception($"Ya existe ese numero de telefono {dto.Telefono}");
            }

            var usuario = await BuscarPorId(id);

            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.FechaNacimiento = dto.FechaNacimiento;
            usuario.Dni = dto.Dni;
            usuario.Nacionalidad = dto.Nacionalidad;
            usuario.Telefono = dto.Telefono;
            usuario.Email = dto.Email;
            usuario.CategoriaCarnet = dto.CategoriaCarnet;
            usuario.FechaVencimientoCarnet = dto.FechaVencimientoCarnet;

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioDetalleDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                Dni = usuario.Dni,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                CategoriaCarnet = usuario.CategoriaCarnet,
                FechaVencimientoCarnet = usuario.FechaVencimientoCarnet
            };
        }

        public async Task<UsuarioDetalleDto> Remover(int id)
        {
            var usuario = await BuscarPorId(id);
            _context.Remove(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioDetalleDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                Dni = usuario.Dni,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                CategoriaCarnet = usuario.CategoriaCarnet,
                FechaVencimientoCarnet = usuario.FechaVencimientoCarnet
            };
        }


        private async Task<Usuario> BuscarPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                throw new Exception($"El usuario con el id {id} no existe");
            }

            return usuario;
        }
    }

}

