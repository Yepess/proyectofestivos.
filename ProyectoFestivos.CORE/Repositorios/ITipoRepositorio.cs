using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFestivos.CORE.Repositorios
{
    public interface ITipoRepositorio
    {
        Task<IEnumerable<Tipo>> ObtenerTodos();

        Task<Tipo> Obtener(int Id);

        Task<Tipo> Agregar(Tipo Seleccion);

        Task<Tipo> Modificar(Tipo Seleccion);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<Tipo>> Buscar(int Tipo, string Dato);
    }
}
