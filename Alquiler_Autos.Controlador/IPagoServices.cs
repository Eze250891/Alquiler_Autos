using Alquiler_Autos.Controlador.DTOs.Pago;

namespace Alquiler_Autos.Controlador
{
    public interface IPagoServices
    {
        Task<PagoDetalleDto> Actualizar(int id, PagoCrearDto dto);
        Task<PagoDetalleDto> Crear(PagoCrearDto dto);
        Task<PagoDetalleDto> ObtenerPorId(int id);
        Task<List<PagoDetalleDto>> ObtenerTodos();
        Task<PagoDetalleDto> Remover(int id);
    }
}