using Alquiler_Autos.Controlador.DTOs.TipoDeCombustible;

namespace Alquiler_Autos.Controlador
{
    public interface ITipoDeCombustibleServices
    {
        Task<TipoDeCombustibleDetalleDto> Actualizar(int id, TipoDeCombustibleCrearDto dto);
        Task<TipoDeCombustibleDetalleDto> Crear(TipoDeCombustibleCrearDto dto);
        Task<TipoDeCombustibleDetalleDto> ObtenerPorId(int id);
        Task<List<TipoDeCombustibleDetalleDto>> ObtenerTodos();
        Task<TipoDeCombustibleDetalleDto> Remover(int id);
    }
}