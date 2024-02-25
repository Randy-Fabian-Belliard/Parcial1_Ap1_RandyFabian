using System.ComponentModel.DataAnnotations;

namespace  Parcial1_Ap1_RandyFabian.Models
{
    public class Metas
    {
        [Key]
        public int MetaId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Descripcion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El campo debe ser mayor que cero")]
        public decimal Monto { get; set; }

    }
}