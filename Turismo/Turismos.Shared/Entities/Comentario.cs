
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismos.Shared.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        [Display(Name = "Calificación de 1 a 5")] // Etiquetas nombre campo
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Indica que hace un salto de nulos)
        public int Calificacion { get; set; }
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string? Descripcion { get; set; }

        public ICollection<Cliente>? Cliente { get; set; }

    }
}
