using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Turismos.Shared.Entities
{
    public class Transporte
    {
        public int Id { get; set; }
        [Display(Name = "Compañia")] // Etiquetas nombre campo
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener unicamente 100 caracteres")] //Es la longitud de caracteres del campo
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Indica que hace un salto de nulos)
        public string Compania { get; set; }
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        [Display(Name = "Fecha de Recogida")]
        [DataType(DataType.Date)]
        public string FechaRecogida { get; set; }
        [Required(ErrorMessage = "El campo {2} es obligatorio")]
        [Display(Name = "Fecha de finalización del recorrido")]
        [DataType(DataType.Date)]
        public string FechaFinal { get; set; }

        [JsonIgnore]
        public ICollection<Viaje> Viajes { get; set; }
    }
}
