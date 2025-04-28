using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.CORE.Servicios;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.Aplicacion.Servicios
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<Festivo> Obtener(int id)
        {
            return await repositorio.Obtener(id);
        }

        public async Task<Festivo> Agregar(Festivo festivo)
        {
            if (!ValidarFestivo(festivo))
                throw new Exception("Datos de fecha inválidos");

            return await repositorio.Agregar(festivo);
        }

        public async Task<Festivo> Modificar(Festivo festivo)
        {
            if (!ValidarFestivo(festivo))
                throw new Exception("Datos de fecha inválidos");

            return await repositorio.Modificar(festivo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }

        public async Task<IEnumerable<Festivo>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public bool ValidarFestivo(Festivo festivo)
        {
            if (festivo.Dia <= 0 || festivo.Dia > 31)
                return false;
            if (festivo.Mes <= 0 || festivo.Mes > 12)
                return false;
            return true;
        }

        public Task<bool> ValidarFestivo(DateTime fecha)
        {
           throw new NotImplementedException(); 
        }
    }
}
