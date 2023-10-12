using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.SHARED.Entities
{
    public class Comentario
    {

        public int Id { get; set; }
        [Display(Name = "Calificación")] // Etiquetas nombre campo
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Indica que hace un salto de nulos)
        [DataType(DataType.MultilineText)]
        public string? Calificacion { get; set; }
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string? Descripcion { get; set; }
    }
}
