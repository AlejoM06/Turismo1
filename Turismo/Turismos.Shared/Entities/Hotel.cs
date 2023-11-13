using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Turismos.Shared.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Hotel")] // Etiquetas nombre campo
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener unicamente 100 caracteres")] //Es la longitud de caracteres del campo
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Indica que hace un salto de nulos)
        public string NombreHotel { get; set; }
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        [Display(Name = "Cantidad de habitaciones")]
        public string Habitaciones { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [JsonIgnore]
        public ICollection<Viaje> Viajes { get; set; }
    }
}
