using System.ComponentModel.DataAnnotations;

namespace software.Models
{
    public class Producto
    {
        [Key]
        public required string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public required string Categoria { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public required string Cantidad { get; set; }

        [Required(ErrorMessage = "La ubicación es obligatoria")]
        public required string Ubicacion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Vencimiento { get; set; }

        public string EstadoStock { get; set; } = "Disponible";

        [Required]
        [DataType(DataType.Currency)]
        public decimal ValorTotal { get; set; }

        public string Estado => DeterminarEstado();

        private string DeterminarEstado()
        {
            var diasParaVencer = (Vencimiento - DateTime.Now).Days;
            
            if (diasParaVencer < 0)
                return "Vencido";
            else if (diasParaVencer < 30)
                return "Próximo a vencer";
            else
                return "Vigente";
        }
    }
}