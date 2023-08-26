using Alquiler_Autos.Controlador;
using Alquiler_Autos.Controlador.DTOs.FormaDePago;
using Alquiler_Autos.Controlador.DTOs.TipoDeCombustible;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alquiler_Autos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeCombustibleController : ControllerBase
    {
        private readonly ITipoDeCombustibleServices _services;
        public TipoDeCombustibleController(ITipoDeCombustibleServices services)
        {
            _services = services;
        }

        // GET: api/<TipoDeCombustibleController>
        [HttpGet]
        public async Task<List<TipoDeCombustibleDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<TipoDeCombustibleController>/5
        [HttpGet("{id}")]
        public async Task<TipoDeCombustibleDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<TipoDeCombustibleController>
        [HttpPost]
        public async Task<TipoDeCombustibleDetalleDto> Post([FromBody] TipoDeCombustibleCrearDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<TipoDeCombustibleController>/5
        [HttpPut("{id}")]
        public async Task<TipoDeCombustibleDetalleDto> Put(int id, [FromBody] TipoDeCombustibleCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<TipoDeCombustibleController>/5
        [HttpDelete("{id}")]
        public async Task<TipoDeCombustibleDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
