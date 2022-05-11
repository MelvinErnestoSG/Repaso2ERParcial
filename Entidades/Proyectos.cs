using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_Ap2_Melvin_2008_0385.Entidades
{
    public class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public String Descripcion { get; set; }

        [ForeignKey("ProyectoId")]
        public virtual List<ProyectosDetalle> ProyectoDetalle { get; set; } = new List<ProyectosDetalle>();
    }
}
