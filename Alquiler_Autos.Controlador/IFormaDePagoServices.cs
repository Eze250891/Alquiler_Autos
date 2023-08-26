using Alquiler_Autos.Controlador.DTOs.FormaDePago;

namespace Alquiler_Autos.Controlador
{
    public interface IFormaDePagoServices
    {
        Task<FormaDePagoDetalleDto> Actualizar(int id, FormaDePagoCrearDto dto);
        Task<FormaDePagoDetalleDto> Crear(FormaDePagoCrearDto dto);
        Task<FormaDePagoDetalleDto> ObtenerPorId(int id);
        Task<List<FormaDePagoDetalleDto>> ObtenerTodos();
        Task<FormaDePagoDetalleDto> Remover(int id);
    }
}