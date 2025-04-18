using Microsoft.EntityFrameworkCore;
using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.Dominio.Entidades;
using ProyectoFestivos.Persistencia.Contexto;

namespace ProyectoFestivos.Infraestructura.Repositorios
{
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly FestivosContext _contexto;

        public TipoRepositorio(FestivosContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await _contexto.Tipos.ToListAsync();
        }

        public async Task<Tipo> Obtener(int id)
        {
            return await _contexto.Tipos.FindAsync(id);
        }

        public async Task<Tipo> Agregar(Tipo tipo)
        {
            _contexto.Tipos.Add(tipo);
            await _contexto.SaveChangesAsync();
            return tipo;
        }

        public async Task<Tipo> Modificar(Tipo tipo)
        {
            _contexto.Tipos.Update(tipo);
            await _contexto.SaveChangesAsync();
            return tipo;
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipo = await Obtener(id);
            if (tipo == null) return false;

            _contexto.Tipos.Remove(tipo);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tipo>> Buscar(int tipoId, string dato)
        {
            return await _contexto.Tipos
                .Where(t => t.Id == tipoId && t.Nombre.Contains(dato))
                .ToListAsync();
        }
    }
}

