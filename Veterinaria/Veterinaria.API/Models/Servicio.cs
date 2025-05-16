using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.API.Models
{
    /// <summary>
    /// Representa un servicio ofrecido por la veterinaria.
    /// </summary>
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Precio { get; set; }
    }
}
