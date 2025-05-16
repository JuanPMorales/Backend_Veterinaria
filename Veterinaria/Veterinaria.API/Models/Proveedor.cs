using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.API.Models
{
    /// <summary>
    /// Representa un proveedor de productos para la veterinaria.
    /// </summary>
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Telefono { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
