using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.CORE.Servicios;
using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFestivos.Aplicacion.Servicios
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio _repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        public Task<Festivo> Obtener(int Id)
        {
            return _repositorio.Obtener(Id);
        }

        public Task<Festivo> Agregar(Festivo festivo)
        {
            return _repositorio.Agregar(festivo);
        }

        public Task<Festivo> Modificar(Festivo festivo)
        {
            return _repositorio.Modificar(festivo);
        }

        public Task<bool> Eliminar(int Id)
        {
            return _repositorio.Eliminar(Id);
        }

        public Task<IEnumerable<Festivo>> Buscar(int Tipo, string Dato)
        {
            return _repositorio.Buscar(Tipo, Dato);
        }
    }
}
