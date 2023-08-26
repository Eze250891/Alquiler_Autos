using Alquiler_Autos.Controlador.DTOs.Vehiculo;

namespace Alquiler_Autos.Controlador
{
    public interface IVehiculoServices
    {
        Task<VehiculoDetalleDto> Actualizar(int id, VehiculoCrearDto dto);
        Task<VehiculoDetalleDto> Crear(VehiculoCrearDto dto);
        Task<VehiculoDetalleDto> ObtenerPorId(int id);
        Task<List<VehiculoDetalleDto>> ObtenerTodos();
        Task<VehiculoDetalleDto> Remover(int id);
    }
}