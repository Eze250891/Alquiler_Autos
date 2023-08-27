using Alquiler_Autos.Controlador.DTOs.Usuario;

namespace Alquiler_Autos.Controlador
{
    public interface IUsuarioServices
    {
        Task<UsuarioDetalleDto> Actualizar(int id, UsuarioCrearDto dto);
        Task<UsuarioDetalleDto> Crear(UsuarioCrearDto dto);
        Task<UsuarioDetalleDto> ObtenerPorId(int id);
        Task<List<UsuarioDetalleDto>> ObtenerTodos();
        Task<UsuarioDetalleDto> Remover(int id);
    }
}