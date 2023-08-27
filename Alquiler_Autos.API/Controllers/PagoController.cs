using Alquiler_Autos.Controlador;
using Alquiler_Autos.Controlador.DTOs.Pago;
using Alquiler_Autos.Controlador.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alquiler_Autos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoServices _services;

        public PagoController(IPagoServices services)
        {
            _services = services;
        }

        // GET: api/<PagoController>
        [HttpGet]
        public async Task<List<PagoDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<PagoController>/5
        [HttpGet("{id}")]
        public async Task<PagoDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<PagoController>
        [HttpPost]
        public async Task<PagoDetalleDto> Post([FromBody] PagoCrearDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<PagoController>/5
        [HttpPut("{id}")]
        public async Task<PagoDetalleDto> Put(int id, [FromBody] PagoCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<PagoController>/5
        [HttpDelete("{id}")]
        public async Task<PagoDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
