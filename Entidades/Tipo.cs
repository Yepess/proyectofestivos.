
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProyectoFestivos.Dominio.Entidades
{
    [Table("Tipo")]
    public class Tipo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo"), StringLength(100)]
        public required string Nombre { get; set; }

        public ICollection<Festivo> Festivos { get; set; } //relacion uno a muchos con Festivos 
    }
}
