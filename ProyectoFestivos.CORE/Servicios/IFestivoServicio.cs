using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFestivos.CORE.Servicios
{
    public interface IFestivoServicio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();

        Task<Festivo> Obtener(int Id);

        Task<Festivo> Agregar(Festivo festivo);

        Task<Festivo> Modificar(Festivo festivo);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<Festivo>> Buscar(int Tipo, string Dato);

        Task<bool> ValidarFestivo(DateTime fecha); // se agrego esta linea para la validacion de las fechas 
        bool ValidarFestivo(Festivo festivo);
    }
}

