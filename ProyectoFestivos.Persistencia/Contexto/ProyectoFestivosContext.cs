using Microsoft.EntityFrameworkCore;
using ProyectoFestivos.Dominio.Entidades;


namespace ProyectoFestivos.Persistencia.Contexto
{
    public class FestivosContext : DbContext
    {
        public FestivosContext(DbContextOptions<FestivosContext> options)
            : base(options)
        {
        }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Festivo> Festivos { get; set; }

        void onModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Tipo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entidad.HasMany(e => e.Festivos)
                    .WithOne(e => e.Tipo)
                    .HasForeignKey(e => e.IdTipo)
                    .OnDelete(DeleteBehavior.Cascade);
            });

           
            modelBuilder.Entity<Festivo>(entidad =>
            {
                entidad.HasKey(e => e.Id);

                entidad.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entidad.Property(e => e.Dia)
                    .IsRequired();

                entidad.Property(e => e.Mes)
                    .IsRequired();

                entidad.Property(e => e.DiasPascua)
                    .IsRequired();

                entidad.HasOne(e => e.Tipo)
                    .WithMany(e => e.Festivos)
                    .HasForeignKey(e => e.IdTipo)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
