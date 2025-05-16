using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.API.Models
{
    /// <summary>
    /// Representa un producto vendido o utilizado por la veterinaria.
    /// </summary>
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int IdProveedor { get; set; }

        [ForeignKey("IdProveedor")]
        public virtual Proveedor Proveedor { get; set; }

        public virtual ICollection<CitaProducto> CitaProductos { get; set; }
    }
}
