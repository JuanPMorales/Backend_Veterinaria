using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.API.Models
{
    /// <summary>
    /// Representa una cita veterinaria para una mascota.
    /// </summary>
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public int IdMascota { get; set; }

        [ForeignKey("IdMascota")]
        public virtual Mascota Mascota { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [ForeignKey("IdServicio")]
        public virtual Servicio Servicio { get; set; }

        public virtual ICollection<CitaProducto> CitaProductos { get; set; }
    }
}
