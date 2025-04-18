using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoFestivos.CORE.Servicios;
using ProyectoFestivos.Infraestructura.Repositorios;
using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.Aplicacion.Servicios;
using ProyectoFestivos.Persistencia.Contexto;


namespace ProyectoFestivos.Presentacion.DI
{
    public static class InyeccionDependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios,
                                                               IConfiguration configuracion)
        {
            servicios.AddDbContext<FestivosContext>(opciones =>
            {
                opciones.UseSqlServer(configuracion.GetConnectionString("FestivosConnection"));
            });

            servicios.AddTransient<IFestivoRepositorio, FestivoRepositorio>();
            servicios.AddTransient<ITipoRepositorio, TipoRepositorio>();

            servicios.AddTransient<IFestivoServicio, FestivoServicio>();
            servicios.AddTransient<ITipoServicio, TipoServicio>();

            return servicios;
        }
    }
}


