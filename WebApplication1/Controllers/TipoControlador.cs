using Microsoft.AspNetCore.Mvc;
using ProyectoFestivos.CORE.Servicios;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposController : ControllerBase
    {
        private readonly ITipoServicio servicio;

        public TiposController(ITipoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo>> Obtener(int id)
        {
            var tipo = await servicio.Obtener(id);
            if (tipo == null) return NotFound();
            return tipo;
        }

        [HttpPost]
        public async Task<ActionResult<Tipo>> Agregar(Tipo tipo)
        {
            var nuevoTipo = await servicio.Agregar(tipo);
            return CreatedAtAction(nameof(Obtener), new { id = nuevoTipo.Id }, nuevoTipo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Modificar(int id, Tipo tipo)
        {
            if (id != tipo.Id) return BadRequest();
            await servicio.Modificar(tipo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await servicio.Eliminar(id);
            return NoContent();
        }
    }
}
