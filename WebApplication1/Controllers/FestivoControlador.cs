using Microsoft.AspNetCore.Mvc;
using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.Presentacion.Controllers
{
    public class FestivoController : Controller
    {
        private readonly IFestivoRepositorio _repositorio;

        public FestivoController(IFestivoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IActionResult> Index()
        {
            var festivos = await _repositorio.ObtenerTodos();
            return View(festivos);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Festivo festivo)
        {
            if (ModelState.IsValid)
            {
                await _repositorio.Agregar(festivo);
                return RedirectToAction("Index");
            }
            return View(festivo);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var festivo = await _repositorio.Obtener(id);
            return View(festivo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Festivo festivo)
        {
            if (ModelState.IsValid)
            {
                await _repositorio.Modificar(festivo);
                return RedirectToAction("Index");
            }
            return View(festivo);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var festivo = await _repositorio.Obtener(id);
            return View(festivo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositorio.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
