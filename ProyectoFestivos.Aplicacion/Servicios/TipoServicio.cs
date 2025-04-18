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
    public class TipoServicio : ITipoServicio
    {
        private readonly ITipoRepositorio _repositorio;

        public TipoServicio(ITipoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        public Task<Tipo> Obtener(int Id)
        {
            return _repositorio.Obtener(Id);
        }

        public Task<Tipo> Agregar(Tipo tipo)
        {
            return _repositorio.Agregar(tipo);
        }

        public Task<Tipo> Modificar(Tipo tipo)
        {
            return _repositorio.Modificar(tipo);
        }

        public Task<bool> Eliminar(int Id)
        {
            return _repositorio.Eliminar(Id);
        }

        public Task<IEnumerable<Tipo>> Buscar(int Tipo, string Dato)
        {
            return _repositorio.Buscar(Tipo, Dato);
        }
    }
}
