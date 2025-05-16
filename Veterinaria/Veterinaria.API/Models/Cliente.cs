using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.API.Models
{
    /// <summary>
    /// Representa a un cliente en la tienda.
    /// </summary>
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; } // Clave primaria

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(150)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        public virtual ICollection<Mascota> Mascotas { get; set; }

    }
}
