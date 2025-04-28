using Microsoft.AspNetCore.Mvc;
using ProyectoFestivos.CORE.Servicios;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestivosController : ControllerBase
    {
        private readonly IFestivoServicio servicio;

        public FestivosController(IFestivoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Festivo>> Obtener(int id)
        {
            var festivo = await servicio.Obtener(id);
            if (festivo == null) return NotFound();
            return festivo;
        }

        [HttpPost]
        public async Task<ActionResult<Festivo>> Agregar(Festivo festivo)
        {
            var nuevoFestivo = await servicio.Agregar(festivo);
            return CreatedAtAction(nameof(Obtener), new { id = nuevoFestivo.Id }, nuevoFestivo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Modificar(int id, Festivo festivo)
        {
            if (id != festivo.Id) return BadRequest();
            await servicio.Modificar(festivo);
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
