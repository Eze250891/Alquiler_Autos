using Alquiler_Autos.Controlador;
using Alquiler_Autos.Controlador.DTOs.Usuario;
using Alquiler_Autos.Controlador.DTOs.Vehiculo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alquiler_Autos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _services;

        public UsuarioController(IUsuarioServices services)
        {
            _services = services;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<List<UsuarioDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<UsuarioDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<UsuarioDetalleDto> Post([FromBody] UsuarioCrearDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<UsuarioDetalleDto> Put(int id, [FromBody] UsuarioCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<UsuarioDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
