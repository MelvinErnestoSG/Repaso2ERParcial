using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_Ap2_Melvin_2008_0385.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int ProyectoDetalleId { get; set; }
        public int ProyectoId { get; set; }
        public int TipoId { get; set; }

        public Proyectos Proyectos { get; set; }

        [ForeignKey("TipoId")]
        public TiposTareas TiposTareas { get; set; }

    }
}
