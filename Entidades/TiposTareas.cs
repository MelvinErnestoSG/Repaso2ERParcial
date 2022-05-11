using System.ComponentModel.DataAnnotations;

namespace P2_Ap2_Melvin_2008_0385.Entidades
{
    public class TiposTareas
    {
        [Key]
        public int TipoId { get; set; }
        public string TipoTarea { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }
    }
}
