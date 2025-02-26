using Microsoft.EntityFrameworkCore;
using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFestivos.Persistencia.Contexto
{
    public class ProyectoFestivosContext : DbContext
    {
        public ProyectoFestivosContext(DbContextOptions<ProyectoFestivosContext> options)
            : base(options)
        {

        }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Festivo> Festivos { get; set; }
        
        void onModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tipo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
                entidad.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            });

            builder.Entity<Festivo>(entidad =>
            {
            entidad.HasKey(e => e.Id);
            entidad.HasIndex(e => e.Nombre).IsUnique();
            entidad.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entidad.Property(e => e.Dia).IsRequired();
            entidad.Property(e => e.Mes).IsRequired();
            entidad.Property(e => e.DiasPascua).IsRequired();
            entidad.HasOne(e => e.Tipo)
                   .WithMany(e => e.Festivos)
                   .HasForeignKey(e => e.IdTipo);

            });
        }


    }
}
