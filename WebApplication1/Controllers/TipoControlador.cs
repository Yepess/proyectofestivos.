using Microsoft.AspNetCore.Mvc;
using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.Presentacion.Controllers
{
    public class TipoControlador
    {
        public class TipoController : Controller
        {
            private readonly ITipoRepositorio _repositorio;

            public TipoController(ITipoRepositorio repositorio)
            {
                _repositorio = repositorio;
            }

            // GET: /Tipo/
            public async Task<IActionResult> Index()
            {
                var tipos = await _repositorio.ObtenerTodos();
                return View(tipos);
            }

            // GET: /Tipo/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: /Tipo/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Tipo tipo)
            {
                if (ModelState.IsValid)
                {
                    await _repositorio.Agregar(tipo);
                    return RedirectToAction(nameof(Index));
                }
                return View(tipo);
            }

            // GET: /Tipo/Edit/5
            public async Task<IActionResult> Edit(int id)
            {
                var tipo = await _repositorio.Obtener(id);
                if (tipo == null)
                {
                    return NotFound();
                }
                return View(tipo);
            }

            // POST: /Tipo/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(Tipo tipo)
            {
                if (ModelState.IsValid)
                {
                    await _repositorio.Modificar(tipo);
                    return RedirectToAction(nameof(Index));
                }
                return View(tipo);
            }

            // GET: /Tipo/Delete/5
            public async Task<IActionResult> Delete(int id)
            {
                var tipo = await _repositorio.Obtener(id);
                if (tipo == null)
                {
                    return NotFound();
                }
                return View(tipo);
            }

            // POST: /Tipo/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await _repositorio.Eliminar(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
