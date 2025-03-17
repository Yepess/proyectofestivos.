using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.Dominio.Entidades;
using ProyectoFestivos.Persistencia.Contexto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFestivos.Infraestructura.Repositorios
{
    public class FestivoRepositorio : IFestivoRepositorio
    {
        private readonly FestivosContext _contexto;

        public FestivoRepositorio(FestivosContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await _contexto.Festivos.Include(f => f.Tipo).ToListAsync();
        }

        public async Task<Festivo> Obtener(int Id)
        {
            return await _contexto.Festivos.Include(f => f.Tipo).FirstOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<Festivo> Agregar(Festivo festivo)
        {
            _contexto.Festivos.Add(festivo);
            await _contexto.SaveChangesAsync();
            return festivo;
        }

        public async Task<Festivo> Modificar(Festivo festivo)
        {
            _contexto.Festivos.Update(festivo);
            await _contexto.SaveChangesAsync();
            return festivo;
        }

        public async Task<bool> Eliminar(int Id)
        {
            var festivo = await Obtener(Id);
            if (festivo == null) return false;

            _contexto.Festivos.Remove(festivo);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Festivo>> Buscar(int Tipo, string Dato)
        {
            return await _contexto.Festivos
                .Where(f => f.IdTipo == Tipo && f.Nombre.Contains(Dato))
                .ToListAsync();
        }
    }
}
