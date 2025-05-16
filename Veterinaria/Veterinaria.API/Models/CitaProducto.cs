using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.API.Models
{
    /// <summary>
    /// Representa los productos utilizados durante una cita.
    /// </summary>
    public class CitaProducto
    {
        public int IdCita { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        [ForeignKey("IdCita")]
        public virtual Cita Cita { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }
    }
}
