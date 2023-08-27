using Alquiler_Autos.Controlador.DTOs.Reserva;

namespace Alquiler_Autos.Controlador
{
    public interface IReservaServices
    {
        Task<ReservaDetalleDto> Actualizar(int id, ReservaCrearDto dto);
        Task<ReservaDetalleDto> Crear(ReservaCrearDto dto);
        Task<ReservaDetalleDto> ObtenerPorId(int id);
        Task<List<ReservaDetalleDto>> ObtenerTodos();
        Task<ReservaDetalleDto> Remover(int id);
    }
}