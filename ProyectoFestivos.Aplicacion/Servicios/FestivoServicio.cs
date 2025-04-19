using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.CORE.Servicios;
using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFestivos.Aplicacion
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Festivo> Agregar(Festivo festivo)
        {
            return await repositorio.Agregar(festivo);
        }

        public async Task<IEnumerable<Festivo>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Festivo> Modificar(Festivo festivo)
        {
            return await repositorio.Modificar(festivo);
        }

        public async Task<Festivo> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<bool> ValidarFestivo(DateTime fecha)
        {
            var festivos = await repositorio.ObtenerTodos();

            // Validar por día y mes
            bool esFestivoFijo = festivos.Any(f => f.Dia == fecha.Day && f.Mes == fecha.Month);

            // Validar si es festivo relativo a Pascua
            DateTime pascua = CalcularPascua(fecha.Year);
            bool esFestivoRelativo = festivos
                .Where(f => f.DiasPascua != 0)
                .Any(f => pascua.AddDays(f.DiasPascua).Date == fecha.Date);

            return esFestivoFijo || esFestivoRelativo;
        }

        private DateTime CalcularPascua(int year)
        {
            // Algoritmo de cálculo de dias de pascua
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(year, month, day);
        }
    }
}
