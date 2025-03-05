using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFestivos.Dominio.Entidades
{
    
        [Table("Festivo")]
        public class Festivo
        {
            [Column("Id")]
            public int Id { get; set; }

            [Column("Nombre"), StringLength(100)]
            public required string Nombre { get; set; }

            [Column("Dia")]
            public int Dia { get; set; }

            [Column("Mes")]
            public int Mes { get; set; }

            [Column("DiasPascua")]
            public int DiasPascua { get; set; }

            [Column("IdTipo")]
            public int IdTipo { get; set; }

            public Tipo Tipo { get; set; }
        }
}
