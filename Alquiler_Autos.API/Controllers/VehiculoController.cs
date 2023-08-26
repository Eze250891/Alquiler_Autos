using Alquiler_Autos.Controlador;
using Alquiler_Autos.Controlador.DTOs.TipoDeCombustible;
using Alquiler_Autos.Controlador.DTOs.Vehiculo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alquiler_Autos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoServices _services;

        public VehiculoController(IVehiculoServices services)
        {
            _services = services;
        }


        // GET: api/<VehiculoController>
        [HttpGet]
        public async Task<List<VehiculoDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<VehiculoController>/5
        [HttpGet("{id}")]
        public async Task<VehiculoDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<VehiculoController>
        [HttpPost]
        public async Task<VehiculoDetalleDto> Post([FromBody] VehiculoCrearDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<VehiculoController>/5
        [HttpPut("{id}")]
        public async Task<VehiculoDetalleDto> Put(int id, [FromBody] VehiculoCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<VehiculoController>/5
        [HttpDelete("{id}")]
        public async Task<VehiculoDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
