using Alquiler_Autos.Controlador.DTOs.TipoDeCombustible;

namespace Alquiler_Autos.Controlador
{
    public interface ITipoDeCombustibleServices
    {
        Task<TipodeCombustibleDetalleDto> Actualizar(int id, TipoDeCombustibleCrearDto dto);
        Task<TipodeCombustibleDetalleDto> Crear(TipoDeCombustibleCrearDto dto);
        Task<TipodeCombustibleDetalleDto> ObtenerPorId(int id);
        Task<List<TipodeCombustibleDetalleDto>> ObtenerTodos();
        Task<TipodeCombustibleDetalleDto> Remover(int id);
    }
}