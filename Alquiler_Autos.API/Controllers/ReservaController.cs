using Alquiler_Autos.Controlador;
using Alquiler_Autos.Controlador.DTOs.Reserva;
using Alquiler_Autos.Controlador.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alquiler_Autos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServices _services;

        public ReservaController(IReservaServices services)
        {
            _services = services;
        }

       

        // GET: api/<ReservaController>
        [HttpGet]
        public async Task<List<ReservaDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<ReservaController>/5
        [HttpGet("{id}")]
        public async Task<ReservaDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }


        // POST api/<ReservaController>
        [HttpPost]
        public async Task<ReservaDetalleDto> Post([FromBody] ReservaCrearDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<ReservaController>/5
        [HttpPut("{id}")]
        public async Task<ReservaDetalleDto> Put(int id, [FromBody] ReservaCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{id}")]
        public async Task<ReservaDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
