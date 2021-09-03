using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampaniaAplicacion.Models
{
    public class Campania
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nombre es Requerido")]
        [MaxLength(150)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Fecha Inicio es Requerido")]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "Fecha Finalizacion es Requerido")]
        public DateTime FechaFinalizacion { get; set; }
        [MaxLength(600)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Estado es Requerido")]
        public bool Estado { get; set; }

    }
}
