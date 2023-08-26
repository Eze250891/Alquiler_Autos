using Alquiler_Autos.Controlador;
using Alquiler_Autos.Controlador.DTOs.FormaDePago;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alquiler_Autos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaDePagoController : ControllerBase
    {
        private readonly IFormaDePagoServices _services;

        public FormaDePagoController(IFormaDePagoServices services)
        {
            _services = services;
        }


        // GET: api/<FormaDePagoControlador>
        [HttpGet]
        public async Task<List<FormaDePagoDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<FormaDePagoControlador>/5
        [HttpGet("{id}")]
        public async Task<FormaDePagoDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<FormaDePagoControlador>
        [HttpPost]
        public async Task<FormaDePagoDetalleDto> Post([FromBody] FormaDePagoCrearDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<FormaDePagoControlador>/5
        [HttpPut("{id}")]
        public async Task<FormaDePagoDetalleDto> Put(int id, [FromBody] FormaDePagoCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<FormaDePagoControlador>/5
        [HttpDelete("{id}")]
        public async Task<FormaDePagoDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
