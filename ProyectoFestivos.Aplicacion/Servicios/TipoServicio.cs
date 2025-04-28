using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.CORE.Servicios;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.Aplicacion
{
    public class TipoServicio : ITipoServicio
    {
        private readonly ITipoRepositorio repositorio;

        public TipoServicio(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<Tipo> Obtener(int id)
        {
            return await repositorio.Obtener(id);
        }

        public async Task<Tipo> Agregar(Tipo tipo)
        {
            return await repositorio.Agregar(tipo);
        }

        public async Task<Tipo> Modificar(Tipo tipo)
        {
            return await repositorio.Modificar(tipo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }

        public async Task<IEnumerable<Tipo>> Buscar(int tipo, string dato)
        {
            return await repositorio.Buscar(tipo, dato);
        }
    }
}
