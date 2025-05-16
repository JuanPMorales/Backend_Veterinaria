using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.API.Models
{
    /// <summary>
    /// Representa una mascota asociada a un cliente.
    /// </summary>
    public class Mascota
    {
        [Key]
        public int IdMascota { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Especie { get; set; }

        [MaxLength(50)]
        public string Raza { get; set; }

        public int Edad { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }
    }
}
